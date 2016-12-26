using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using ModelTools.ModelData.JMS;
using ModelTools.ModelData.VWI;
using Win32;

namespace ModelTools.Interface
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      Output.NewMessage += new Output.OutputEventHandler(Output_NewMessage);
    }

    private string m_CommonFilePath;

    private void Output_NewMessage(string output)
    {
      OutputGroup_txtOutput.Text += output; // + OutputGroup_txtOutput.Text;
      OutputGroup_txtOutput.Select(OutputGroup_txtOutput.Text.Length, 0);
      //OutputGroup_txtOutput.Focus();
      OutputGroup_txtOutput.ScrollToCaret();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      //Output.WriteLine("Checking registry for Halo CE directory.");
      try
      {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Halo HEK");
        m_CommonFilePath = key.GetValue("EXE Path").ToString() + @"\data";
        //Output.WriteLine("Registry key found. Halo CE Data Directory:");
        //Output.WriteLine(m_CommonFilePath);
      }
      catch
      {
        m_CommonFilePath = @"C:\Program Files\Microsoft Games\Halo Custom Edition\data";
        //Output.WriteLine("Registry key not found. Defaulting Halo CE Data Directory to:\n");
        //Output.WriteLine(m_CommonFilePath);
      }

      ModelData.Globals.DebugPath = Environment.CurrentDirectory + @"\debug.txt";

      FileActive = false;
      FileModified = false;
    }

    private JMSFile m_JMSFile;

    private string m_FilePath;

    private bool m_FileModified = false;
    public bool FileModified
    {
      get { return m_FileModified; }
      set
      {
        m_FileModified = value;

        mnuFile_Save.Enabled = m_FileModified;

        if (m_FileModified)
          MainGroup.Text = Path.GetFileName(m_FilePath) + " *";
        else
          MainGroup.Text = Path.GetFileName(m_FilePath);
        
      }
    }

    private bool m_FileActive = false;
    public bool FileActive
    {
      get { return m_FileActive; }
      set
      {
        m_FileActive = value;

        mnuFile_Open.Enabled = !m_FileActive;
        //mnuFile_Save.Enabled = m_FileActive;
        mnuFile_SaveAs.Enabled = m_FileActive;
        mnuFile_Close.Enabled = m_FileActive;
        // -----
        mnuFile_Import.Enabled = m_FileActive;

        // -----
        MainGroup_lblWelcome.Visible = !m_FileActive;
        // -----
        MainGroup_lblNodeChecksum.Visible = m_FileActive;
        MainGroup_txtNodeChecksum.Visible = m_FileActive;
        MainGroup_btnUpdateNodeChecksum.Visible = m_FileActive;

        if (!m_FileActive)
          MainGroup.Text = "";
      }
    }

    private void UpdateSigFigs()
    {
      try
      {
        ModelData.Globals.FigurePrecision = Convert.ToInt32(txtSigFigs.Text);
      }
      catch {}
      txtSigFigs.Text = ModelData.Globals.FigurePrecision.ToString();
    }

    private void LoadModelData()
    {
      MainGroup_txtNodeChecksum.Text = m_JMSFile.NodeChecksum.ToString();
    }

    private void SaveModelData()
    {
      bool changed = false;

      long nodeChecksum = Convert.ToInt64(MainGroup_txtNodeChecksum.Text);
      if (m_JMSFile.NodeChecksum != nodeChecksum)
      {
        m_JMSFile.NodeChecksum = Convert.ToInt64(MainGroup_txtNodeChecksum.Text);
        changed = true;
      }

      if (changed)
        FileModified = true;
    }

    private void mnuFile_Open_Click(object sender, EventArgs e)
    {
      if (FileActive)
        return;

      UpdateSigFigs();

      HiPerfTimer timer = new HiPerfTimer();

      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "JMS Files (*.jms)|*.jms";
      dialog.Title = "Open JMS File";
      dialog.InitialDirectory = m_CommonFilePath;
      DialogResult result = dialog.ShowDialog();
      if (result != DialogResult.OK)
        return;

      Output.WriteLine("Opening " + dialog.FileName);
      StreamReader sr = new StreamReader(dialog.OpenFile());

      m_FilePath = dialog.FileName;
      m_CommonFilePath = Path.GetDirectoryName(m_FilePath);

      string[] file = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      sr.Close();

      m_JMSFile = new JMSFile();

      Output.Write("Reading JMS file... ");
      Application.DoEvents();

      timer.Start();
      m_JMSFile.ReadFromJMS(file);
      timer.Stop();

      Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
      Output.WriteLine(String.Format("{0} vertices found in JMS input file.", m_JMSFile.Vertices.Length));
      Output.WriteLine("-------------------------");

      Output.Write("Optimising JMS data... ");
      Application.DoEvents();

      timer.Start();
      m_JMSFile.Optimise();
      timer.Stop();

      Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
      Output.WriteLine(String.Format("{0} unique vertices found.", m_JMSFile.UniqueVertices.Count));
      Output.WriteLine("-------------------------");
      

      FileActive = true;
      FileModified = false;

      LoadModelData();
    }

    private void mnuFile_Import_Weights_Click(object sender, EventArgs e)
    {
      if (!FileActive)
        return;

      UpdateSigFigs();

      HiPerfTimer timer = new HiPerfTimer();

      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Vertex Weight Files (*.txt)|*.txt";
      dialog.Title = "Import Weight File";
      dialog.InitialDirectory = m_CommonFilePath;
      DialogResult result = dialog.ShowDialog();
      if (result != DialogResult.OK)
        return;

      Output.WriteLine("Opening " + dialog.FileName);
      StreamReader sr = new StreamReader(dialog.OpenFile());
      
      string[] file = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      sr.Close();

      VWIFile vwi = new VWIFile();
      
      Output.Write("Reading weight file... ");
      Application.DoEvents();

      timer.Start();
      vwi.ReadFromVWI(file);
      timer.Stop();

      Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
      Output.WriteLine(String.Format("{0} vertices found in the weight file.", vwi.Vertices.Length));
      if (vwi.VerticesWithExcessBones != 0)
      {
        Output.WriteLine(String.Format("{0}/{1} vertices have excess bones.", vwi.VerticesWithExcessBones, vwi.Vertices.Length));
        MessageBox.Show(String.Format("{0}/{1} vertices have more than 2 bones weighting them.\r\nOnly the first 2 bones per vertex will be merged.", vwi.VerticesWithExcessBones, vwi.Vertices.Length), "Vertices have excess bones");
      }
      Output.WriteLine("-------------------------");
      Output.Write("Optimising weight data... ");
      Application.DoEvents();

      timer.Start();
      vwi.Optimise();
      timer.Stop();

      Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
      Output.WriteLine(String.Format("{0} unique vertices found.", vwi.UniqueVertices.Count));
      Output.WriteLine("-------------------------");

      Output.Write("Merging weight data... ");
      Application.DoEvents();

      List<ModelTools.ModelData.JMS.Vertex> unmatched;

      timer.Start();
      int matched = m_JMSFile.ImportWeights(vwi, null, out unmatched);
      timer.Stop();

      Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
      Output.WriteLine(String.Format("{0}/{1} vertices matched.", matched, m_JMSFile.UniqueVertices.Count));
      Output.WriteLine("-------------------------");

      if (matched != m_JMSFile.UniqueVertices.Count)
      {
        Output.WriteLine("A full search will be performed on the remaining " + (m_JMSFile.UniqueVertices.Count - matched) + " vertices.");
        Output.Write("Merging remaining weight data... ");
        Application.DoEvents();

        ModelData.Globals.PerformHash = false;
        List<ModelTools.ModelData.JMS.Vertex> altUnmatched;

        timer.Start();
        matched += m_JMSFile.ImportWeights(vwi, unmatched, out altUnmatched);
        timer.Stop();

        unmatched = altUnmatched;
        ModelData.Globals.PerformHash = true;
        
        Output.WriteLine("Done. (" + timer.Duration.ToString("0.00000") + " seconds)");
        Output.WriteLine(String.Format("{0}/{1} vertices now matched.", matched, m_JMSFile.UniqueVertices.Count));
        Output.WriteLine("-------------------------");
      }

      if (matched != m_JMSFile.UniqueVertices.Count)
      {
        StreamWriter sw = new StreamWriter(ModelData.Globals.DebugPath, true);
        sw.WriteLine("\r\n\r\n----------------------------------------------------\r\n");
        sw.WriteLine(DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString());
        sw.WriteLine(String.Format("{0}/{1} vertices matched.", matched, m_JMSFile.UniqueVertices.Count));
        sw.WriteLine(""); 
        sw.WriteLine("JMS unmatched vertices -------------------------------------------");
        sw.WriteLine(""); 
        foreach (ModelTools.ModelData.JMS.Vertex v in unmatched)
        {
          sw.WriteLine(v.Location.ToString());
          //sw.WriteLine("[" + v.Location.GetHashString() + " || " + v.Location.GetHashCode() + "]");
        }
        sw.WriteLine("");
        sw.WriteLine("VWI unmatched vertices -------------------------------------------");
        sw.WriteLine("");
        foreach (ModelTools.ModelData.VWI.Vertex v in vwi.UniqueVertices.Values)
        {
          sw.WriteLine(v.Location.ToString());
          //sw.WriteLine("[" + v.Location.GetHashString() + " || " + v.Location.GetHashCode() + "]");
        }
        sw.Close();

        Output.WriteLine("Dumped vertex mismatch information to:");
        Output.WriteLine(ModelData.Globals.DebugPath);
      }

      FileModified = true;
    }

    private void mnuFile_Close_Click(object sender, EventArgs e)
    {
      if (FileModified)
      {
        DialogResult result = MessageBox.Show("The file has been modified, save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);
        switch (result)
        {
          case DialogResult.Yes:
            mnuFile_Save_Click(sender, e);
            break;
          case DialogResult.Cancel:
            return;
        }
      }
      m_FilePath = "";
      FileModified = false;
      FileActive = false;
      m_JMSFile = null;
      OutputGroup_txtOutput.Clear();
    }

    private void mnuFile_Save_Click(object sender, EventArgs e)
    {
      if (!FileActive)
        return;

      StreamWriter sw = new StreamWriter(new FileStream(m_FilePath, FileMode.Create));
      string[] result = m_JMSFile.WriteToJMS();
      foreach (string s in result)
        sw.WriteLine(s);
      sw.Close();

      FileModified = false;
    }

    private void mnuFile_SaveAs_Click(object sender, EventArgs e)
    {
      if (!FileActive)
        return;

      SaveFileDialog dialog = new SaveFileDialog();
      dialog.Filter = "JMS Files (*.jms)|*.jms";
      dialog.Title = "Save JMS File";
      dialog.InitialDirectory = m_CommonFilePath;
      DialogResult result = dialog.ShowDialog();
      if (result != DialogResult.OK)
        return;

      m_FilePath = dialog.FileName;
      m_CommonFilePath = Path.GetDirectoryName(m_FilePath);

      StreamWriter sw = new StreamWriter(dialog.OpenFile());
      string[] file = m_JMSFile.WriteToJMS();
      foreach (string s in file)
        sw.WriteLine(s);
      sw.Close();

      FileModified = false;
    }

    private void MainGroup_btnUpdateNodeChecksum_Click(object sender, EventArgs e)
    {
      try
      {
        this.SaveModelData();
      }
      catch
      {
        MessageBox.Show("Invalid Node Checksum");
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (FileModified)
      {
        DialogResult result = MessageBox.Show("The file has been modified, save changes?", "Save Changes", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
            mnuFile_Save_Click(sender, e);
      }
    }
  }
}
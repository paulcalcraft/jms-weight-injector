using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModelTools.ModelData.VWI;
using ModelTools.ModelData.JMS;

namespace ModelTools.Interface
{
  public partial class WeightMergeForm : Form
  {
    private VWIFile m_VWIFile;
    private JMSFile m_JMSFile;

    public WeightMergeForm(VWIFile vwiFile, JMSFile jmsFile)
    {
      this.m_VWIFile = vwiFile;
      this.m_JMSFile = jmsFile;
      InitializeComponent();
    }

    private void WeightMergeForm_Load(object sender, EventArgs e)
    {
      lblOutput.Text = String.Format(
        "The weight file has {0} vertices.\n",
        m_VWIFile.Vertices.Length
      );
      lblOutput.Text += "Optimising... ";

      m_VWIFile.Optimise();

      lblOutput.Text += "Done.\n";
      lblOutput.Text += String.Format(
        "{0} unique vertices were found.",
        m_VWIFile.UniqueVertices.Count
      );

    }
  }
}
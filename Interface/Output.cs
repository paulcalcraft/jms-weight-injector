using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTools
{
  public static class Output
  {
    public delegate void OutputEventHandler(string output);

    public static event OutputEventHandler NewMessage;

    public static void WriteLine(string output)
    {
      if (NewMessage != null)
        NewMessage(output+"\r\n");
    }

    public static void Write(string output)
    {
      if (NewMessage != null)
        NewMessage(output);
    }
  }
}

namespace cb_agent.Modules;
using System.Diagnostics;
using cb_agent.Models.DTO;

public class OSManager
{

    public bool StartExe(string path, string? argument)
    {
        try
        {
            string caminhoExe = path;
            Process process = new Process();
            process.StartInfo.Arguments = argument;
            process.StartInfo.FileName = caminhoExe;
            process.Start();
            process.WaitForExit();
            return true;
        }
        catch (Exception Ex)
        {
            return false;
        }

    }

    public List<ProcessListDTO> ListRunningProcesses()
    {
        return Process.GetProcesses()
                      .Select(p => new ProcessListDTO
                      {
                        ProcessId = p.Id,
                        ProcessName= p.ProcessName,
                      })
                      .ToList();
    }
}
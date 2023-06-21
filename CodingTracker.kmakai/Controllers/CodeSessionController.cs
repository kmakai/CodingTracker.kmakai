using CodingTracker.kmakai.Data;
using CodingTracker.kmakai.Models;
using ConsoleTableExt;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingTracker.kmakai.Controllers;

public class CodeSessionController
{
    private readonly DbContext DbContext;
    private List<CodeSession> CodeSessions = new();

    public CodeSessionController(DbContext dbContext)
    {
        DbContext = dbContext;
        CodeSessions = DbContext.GetCodeSessions();
    }

    public void CreateSession()
    {
        string? Date = InputController.GetDateInput();
        string StartTime = InputController.GetStartTimeInput();
        string EndTime = InputController.GetEndTimeInput(StartTime);

        CodeSession codeSession = new()
        {
            Date = Date,
            StartTime = StartTime,
            EndTime = EndTime
        };

        DbContext.Add(codeSession);
        CodeSessions.Add(codeSession);
    }
    public void UpdateSession()
    {
        var id = InputController.GetIdInput();
        var codeSession = CodeSessions.FirstOrDefault(x => x.Id == id);

        if (codeSession is null)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        string? Date = InputController.GetDateInput();
        string StartTime = InputController.GetStartTimeInput();
        string EndTime = InputController.GetEndTimeInput(StartTime);

        codeSession.Date = Date;
        codeSession.StartTime = StartTime;
        codeSession.EndTime = EndTime;

        DbContext.Update(codeSession);
    }

    public void DeleteSession()
    {
        var id = InputController.GetIdInput();
        DbContext.Delete(id);
        CodeSessions.RemoveAll(x => x.Id == id);
    }

    public void ViewSessions()
    {
        ConsoleTableBuilder.From(CodeSessions).ExportAndWriteLine();
    }

}

using CodingTracker.kmakai.Controllers;
using CodingTracker.kmakai.Data;

CodeSessionController codeSessionController = new(new DbContext());
codeSessionController.ViewSessions();
//codeSessionController.UpdateSession();
codeSessionController.DeleteSession();
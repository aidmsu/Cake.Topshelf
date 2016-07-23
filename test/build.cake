#addin "Cake.Topshelf"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    //Executed BEFORE the first task.
    Information("Tools dir: {0}.", EnvironmentVariable("CAKE_PATHS_TOOLS"));
});






///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Install")
    .Description("Installs a Topshelf service")
    .Does(() =>
{
    TopshelfInstall("C:/Services/example.exe", new TopshelfSettings()
    {
        Username = "Admin",
        Password = "Password1",

        Instance = "Example",
        Autostart = true,
        Delayed = true
    });
});



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Install");



///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);

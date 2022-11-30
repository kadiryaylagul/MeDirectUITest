using MeDirect.Driver;
using TechTalk.SpecFlow;

namespace MeDirect.PageMethods
{
    public class Hooks
    {
        [Before]
        public void BeforeTestRun()
        {
            DriverControl.DriverStart();  
            DriverControl.DriverMaximize();
        }

        [After]
        public void AfterTestRun()
        {
            DriverControl.DriverStop();
        }
    }
}

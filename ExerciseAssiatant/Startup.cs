using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExerciseAssiatant.Startup))]
namespace ExerciseAssiatant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

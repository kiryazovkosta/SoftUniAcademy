using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny)
        {
            bool finishColoring = false;

            while (!egg.IsDone() 
                && bunny.Energy > 0 
                && bunny.Dyes.Any(d => !d.IsFinished()))
            {
                foreach (IDye dye in bunny.Dyes.Where(d => !d.IsFinished()))
                {
                    if (finishColoring)
                    {
                        break;
                    }

                    while (true)
                    {
                        egg.GetColored();
                        dye.Use();
                        bunny.Work();

                        if (egg.IsDone() || bunny.Energy == 0)
                        {
                            finishColoring = true;
                            break;
                        }

                        if (dye.IsFinished())
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}

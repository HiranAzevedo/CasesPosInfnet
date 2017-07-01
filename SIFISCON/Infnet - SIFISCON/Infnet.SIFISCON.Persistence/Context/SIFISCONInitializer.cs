using System.Data.Entity;

namespace Infnet.SIFISCON.Persistence.Context
{
    public class SIFISCONInitializer : DropCreateDatabaseIfModelChanges<SIFISCONContext>
    {
        protected override void Seed(SIFISCONContext context)
        {
            base.Seed(context);
        }
    }
}

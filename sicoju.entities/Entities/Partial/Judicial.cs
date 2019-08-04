using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sicoju.entities.Entities
{
    /// <summary>
    /// Partial class used to configure any settings related with database context.
    /// </summary>
    public partial class Judicial : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Judicial"/>.
        /// </summary>
        public Judicial() : base("name=Judicial")
        {
            //Disables automatic table join
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Supabase;

namespace SupaTest.Models
{ 

[Table("Biens")]
    public class Biens : SupabaseModel
    {
        // `ShouldInsert` Set to false so-as to honor DB generated key
        // If the primary key was set by the application, this could be omitted.
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("idImm")]
        public int idImm { get; set; }
    }
}

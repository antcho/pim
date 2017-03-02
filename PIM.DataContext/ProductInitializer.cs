using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DataContext
{
    public class ProductInitializer : DropCreateDatabaseIfModelChanges<PIMContext>
    {

        protected override void Seed(PIMContext context)
        {
            var products = new List<Product>
            {
                new Product{Reference=1564, Name="TV-SUPER64", Description="Une super TV", Price=1984.34M, Category="Télévision", ValidityDate = DateTime.Now, Image="blabla" },
                new Product{Reference=654, Name="La machine à laver", Description="Machine à laver nouveau modèle", Price=299, Category="Gros électroménager", ValidityDate = DateTime.Now, Image="blabla" },
                new Product{Reference=976423, Name="Grille-pain new++", Description="Grille-pain qui grille le pain et le pain de mie", Price=851.54M, Category="Petit électroménager", ValidityDate = DateTime.Now, Image="blabla" },
                new Product{Reference=1564, Name="TV-C3PO", Description="Une télé un peu moins super", Price=542.34M, Category="Télévision", ValidityDate = DateTime.Now, Image="blabla" },

            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

        }
    } 
}

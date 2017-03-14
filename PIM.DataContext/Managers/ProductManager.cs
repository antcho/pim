using Entities;
using PIM.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DataContext.Managers
{
    public class ProductManager
    {
        private EfRepository _repository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProductManager()
        {
            _repository = new EfRepository(ContextFactory.GetContext());
        }

        public int Add(Product p)
        {
           
            _repository.Add<Product>(p);
            _repository.SaveChanges();

            var result = p.Reference;

            return result;
         
        }
        
        public bool Delete(int? id)
        {
            var p = _repository.Get<Product>(id);

            bool result;

            if (p != null)
            {
                    
                _repository.Delete(p);
                    

                //Commit Changes
                _repository.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
           
        }

        public Product Get(int? reference)
        {
            return _repository.Get<Product>(reference);
        }

        public List<Product> GetAll()
        {
            return _repository.Find<Product>(p => p.Reference != null).ToList();
        }

        public List<Product> GetFromCategory(String category)
        {
            return _repository.Find<Product>(p => p.Category.Equals(category)).ToList();
        }
   
        public bool Update(Product p)
        {
            _repository.Update<Product>(p);
            _repository.SaveChanges();

            return true;
            
        }
    }
}

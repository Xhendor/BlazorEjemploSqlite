using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Database
{

    public class ProductServices
    {
        #region Private members
        private ProductDbContext dbContext;
        #endregion
        #region Constructor
        public ProductServices()
        {



            dbContext = new ProductDbContext();

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        
        #endregion
        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProductAsync()
        {
            return await dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetProductAsync(Product product)
        {
            return  dbContext.Product.AsNoTracking().Single(e => e.Id==product.Id);
        }
        /// <summary>
        /// This method add a new product to the DbContext and saves it
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// 
        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Add(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var productExist = dbContext.Product.AsNoTracking().FirstOrDefault(p => p.Id == product.Id);
                if (productExist != null)
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        /// <summary>
        /// This method removes and existing product from the DbContext and saves it
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Remove(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }




}

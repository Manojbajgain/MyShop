﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Myshop.cor.Models;

namespace Myshop.DAtaacess.In_memory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert (Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToupdate = products.Find(p => p.Id == product.Id);
            if ( productToupdate != null)
            {
                productToupdate = product;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else {
                throw new Exception("Product not Found");
            }
                    
                }
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
        public void Delete (string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

            }
        }
    


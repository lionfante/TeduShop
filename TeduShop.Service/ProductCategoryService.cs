using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductCategoryService
    {
        void Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        void Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllByParentId(int parentId);
        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        ProductCategory GetById(int id);
        IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ProductCategory productCategory)
        {
            _productCategoryRepository.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


        
    }
}

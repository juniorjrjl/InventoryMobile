using System.Collections.ObjectModel;
using InventoryMobile.Models.Response;
using InventoryMobile.Repositories.Product;

namespace InventoryMobile.ViewModels
{
    public partial class ProductsViewModel : BaseViewModel
    {
        private readonly IProductRepository _repositorty;

        public ObservableCollection<ProductResponse> Products { get; set; } = new ObservableCollection<ProductResponse>();

        public ProductsViewModel(IProductRepository repository)
        {
            _repositorty = repository;
        }

        internal async Task InitAsync()
        {
            IsBusy = true;
            var products = await _repositorty.GetAsync();
            Products.Clear();
            foreach(var product in products){
                Products.Add(product);
            }
            IsBusy = false;
        }

    }
}
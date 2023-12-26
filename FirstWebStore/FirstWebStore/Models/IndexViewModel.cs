namespace FirstWebStore.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductBase> ProductBase { get; }
        public FilterViewModel FilterViewModel { get; }

        public IndexViewModel(IEnumerable<ProductBase> productBase, FilterViewModel filterViewModel)
        {
            ProductBase = productBase;
            FilterViewModel = filterViewModel;
        }
    }
}

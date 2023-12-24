using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Deneme4.Core.Common;
using Deneme4.Core.ResultModels;
using Deneme4.UI.Models;
using Newtonsoft.Json;

namespace Deneme4.UI.Client
{
    public class ProductClient
    {
        private readonly HttpClient _httpClient;

        public ProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        public async Task<Result<ProductModel>> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductModel>(responseData);
                if (result != null)
                    return new Result<ProductModel>(true, ResultConstant.RecordFound, result);
                return new Result<ProductModel>(false, ResultConstant.RecordNotFound);
            }
            return new Result<ProductModel>(false, ResultConstant.RecordNotFound);
        }

        public async Task<Result<List<ProductModel>>> GetProducts()
        {
            var response = await _httpClient.GetAsync($"/api/v1/Product/GetProducts");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductModel>>(responseData);
                if (result.Any())
                    return new Result<List<ProductModel>>(true, ResultConstant.RecordFound, result.ToList());
                return new Result<List<ProductModel>>(false, ResultConstant.RecordNotFound);
            }
            return new Result<List<ProductModel>>(false, ResultConstant.RecordNotFound);
        }

        public async Task<Result<ProductModel>> CreateProduct(ProductModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("/api/v1/Product", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductModel>(responseData);
                if (result != null)
                    return new Result<ProductModel>(true, ResultConstant.RecordCreateSuccessfully, result);
                else
                    return new Result<ProductModel>(false, ResultConstant.RecordCreateNotSuccessfully);
            }
            return new Result<ProductModel>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

    }
}

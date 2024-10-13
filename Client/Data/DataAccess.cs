using GasCounter.Utilities;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

public class DataAccess
{
    private readonly IJSRuntime _jsRuntime;

    public DataAccess(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    // Veriyi localStorage'a kaydet
    public async Task SaveDataAsync<T>(string key, T value)
    {
        var jsonData = JsonSerializer.Serialize(value);
        await _jsRuntime.InvokeVoidAsync(Constants.SaveData, key, jsonData);
    }

    // localStorage'dan veriyi oku
    public async Task<T> GetDataAsync<T>(string key)
    {
        var jsonData = await _jsRuntime.InvokeAsync<string>(Constants.GetData, key);
        if (jsonData == null)
        {
            return default;
        }
        return JsonSerializer.Deserialize<T>(jsonData);
    }

    // localStorage'dan veriyi sil
    public async Task RemoveDataAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync(Constants.RemoveData, key);
    }
}

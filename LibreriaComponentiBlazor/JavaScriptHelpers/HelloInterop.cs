using Microsoft.JSInterop;

namespace LibreriaComponentiBlazor.JavaScriptHelpers;

public class HelloInterop: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? objReference;

    public HelloInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task CallHelloHelperSayHello(string name)
    {
        var instance = new HelloHelper(name);
        objReference = DotNetObjectReference.Create(instance);
        await jSRuntime.InvokeVoidAsync("fourthFunction", objReference);
    }

    public void Dispose()
    {
        objReference?.Dispose();
    }
}

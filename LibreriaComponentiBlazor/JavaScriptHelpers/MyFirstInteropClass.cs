using Microsoft.JSInterop;

namespace LibreriaComponentiBlazor.JavaScriptHelpers;

public class MyFirstInteropClass
{
    private readonly IJSRuntime jSRuntime;

    public MyFirstInteropClass(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public ValueTask<int> FirstFunction(int a, int b, int c)
    {
        return jSRuntime.InvokeAsync<int>("firstFunction", a, b, c);
    }
    public async Task SecondFunction(string name)
    {
        await jSRuntime.InvokeVoidAsync("secondFunction", name);

    }

    public async Task ThirdFunction()
    {
        await jSRuntime.InvokeVoidAsync("thirdFunction");

    }


}



public class SetUpJwtOptions : IConfigureOptions<MyJwtOptions>
{
    private readonly IConfiguration configuration;
    private string sectionName = "Jwt";

    public SetUpJwtOptions(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public void Configure(MyJwtOptions options)
    {
        configuration.GetSection(sectionName).Bind(options) ;
    }
}

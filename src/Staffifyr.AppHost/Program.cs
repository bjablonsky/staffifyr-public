var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Staffifyr_Web_ApiService>("apiservice");

builder.AddProject<Projects.Staffifyr_Web_UI>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

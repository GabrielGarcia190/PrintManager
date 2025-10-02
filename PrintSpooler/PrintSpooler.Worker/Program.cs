using PrintSpooler.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<PrintWorker>();

var host = builder.Build();
host.Run();

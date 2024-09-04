using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestTask.Extensions;
using TestTask.Profiles;
using TestTask.Repositories;
using TestTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddTransient<IDoctorService,DoctorService>();
builder.Services.AddTransient<IDoctorRepository,DoctorRepository>();

builder.Services.AddTransient<IPatientService,PatientService>();
builder.Services.AddTransient<IPatientRepository,PatientRepository>();

builder.Services.InitEfDbContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(PatientProfile),
    typeof(DoctorProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateEfDbContext();
await app.RunAsync();
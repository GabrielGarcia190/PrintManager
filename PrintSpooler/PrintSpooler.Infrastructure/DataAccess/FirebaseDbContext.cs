using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;

namespace PrintSpooler.Infrastructure.DataAccess;

public class FirestoreContext
{
    public FirestoreDb Firestore { get; }

    public FirestoreContext(IConfiguration configuration)
    {
        var credentialPath = configuration["Firebase:CredentialPath"];
        var projectId = configuration["Firebase:ProjectId"];

        if (string.IsNullOrEmpty(credentialPath))
            throw new InvalidOperationException("Caminho do arquivo de credenciais do Firebase não informado.");

        if (string.IsNullOrEmpty(projectId))
            throw new InvalidOperationException("ProjectId do Firebase não informado.");

        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);


        Firestore = FirestoreDb.Create(projectId);
    }
}
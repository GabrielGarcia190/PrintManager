
using PrintSpooler.Domain.Shared.Results;

namespace PrintSpooler.Application.Printing.Interfaces;

public interface IPrintingService
{
    Task<ResponseData> PrintAllFiles();
}
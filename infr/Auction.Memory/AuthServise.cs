using Auction;
using System.Collections.Generic;
using System.Linq;

public class AuthServise : IAuthServise
{
    private readonly ExcelService _excelService;
    public AuthServise(ExcelService excelService)
    { 
        _excelService = excelService;
    }
    public List<Akk> GetAllAkks()
    {
        return _excelService.GetAkk().ToList();
    }
    public bool Login(string login, string password)
    {
        var akks = _excelService.GetAkk();
        var akk = akks.FirstOrDefault(a => a.Login == login && a.Password == password);
        return akk != null;
    }
    Akk IAuthServise.GetUserByLogin(string login)
    {
        var akks = _excelService.GetAkk();
        return akks.FirstOrDefault(a => a.Login == login);
    }
}
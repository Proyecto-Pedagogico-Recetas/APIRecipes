//using API.IServices;
//using Entities.Entities;
//using Logic.Ilogic;
//using Logic.Logic;
//using Resources.RequestModels;

//namespace API.Services
//{
//    public class UserRolItemService : IUserRolItemService
//    {
//        private readonly IUserRolItemService _userRolItemService;

//        public UserRolItemService(IUserRolItemLogic userRolItemLogic)
//        {
//            _alergenItemLogic = alergenItemLogic;
//        }
//        public List<AlergenItem> GetAlergens()
//        {
//            return _alergenItemLogic.GetAlergens();
//        }


//        int IAlergenItemService.InsertAlergen(AlergenRequest alergenRequest)
//        {
//            return _alergenItemLogic.InsertAlergen(alergenRequest);
//        }

//        public void DeleteAlergen(int id)
//        {
//            _alergenItemLogic.DeleteAlergen(id);
//        }


//    }
//}
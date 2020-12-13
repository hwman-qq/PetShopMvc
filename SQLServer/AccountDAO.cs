using System;
using System.Data;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.Data.SqlServer.Models;
using PetShop.IDAL;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PetShop.SQLServerDAL {
	/// <summary>
	/// Summary description for AccountDALC.
	/// </summary>
	public class AccountDAO : IAccountDO{
        PetShopDbContext db = new PetShopDbContext();

		// Static constants
		private const string SQL_SELECT_ACCOUNT = "SELECT Account.Email, Account.FirstName, Account.LastName, Account.Addr1, Account.Addr2, Account.City, Account.State, Account.Zip, Account.Country, Account.Phone, Profile.LangPref, Profile.FavCategory, Profile.MyListOpt, Profile.BannerOpt FROM Account INNER JOIN Profile ON Account.UserId = Profile.UserId INNER JOIN SignOn ON Account.UserId = SignOn.UserName WHERE SignOn.UserName = @UserId AND SignOn.Password = @Password";
		private const string SQL_SELECT_ADDRESS = "SELECT Account.FirstName, Account.LastName, Account.Addr1, Account.Addr2, Account.City, Account.State, Account.Zip, Account.Country, Account.Phone FROM Account WHERE Account.UserId = @UserId";
		private const string SQL_INSERT_SIGNON = "INSERT INTO SignOn VALUES (@UserId, @Password)";
		private const string SQL_INSERT_ACCOUNT = "INSERT INTO Account VALUES(@UserId, @Email, @FirstName, @LastName, 'OK', @Address1, @Address2, @City, @State, @Zip, @Country, @Phone)";
		private const string SQL_INSERT_PROFILE = "INSERT INTO Profile VALUES(@UserId, @Language, @Category, @ShowFavorites, @ShowBanners)";
		private const string SQL_UPDATE_PROFILE = "UPDATE Profile SET LangPref = @Language, FavCategory = @Category, MyListOpt = @ShowFavorites, BannerOpt = @ShowBanners WHERE UserId = @UserId";
		private const string SQL_UPDATE_ACCOUNT = "UPDATE Account SET Email = @Email, FirstName = @FirstName, LastName = @LastName, Addr1 = @Address1, Addr2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Phone = @Phone WHERE UserId = @UserId";
		private const string PARM_USER_ID = "@UserId";
		private const string PARM_PASSWORD = "@Password";
		private const string PARM_EMAIL = "@Email";
		private const string PARM_FIRST_NAME = "@FirstName";
		private const string PARM_LAST_NAME = "@LastName";
		private const string PARM_ADDRESS1 = "@Address1";
		private const string PARM_ADDRESS2 = "@Address2";
		private const string PARM_CITY = "@City";
		private const string PARM_STATE = "@State";
		private const string PARM_ZIP = "@Zip";
		private const string PARM_COUNTRY = "@Country";
		private const string PARM_PHONE = "@Phone";
		private const string PARM_LANGUAGE = "@Language";
		private const string PARM_CATEGORY = "@Category";
		private const string PARM_SHOW_FAVORITES = "@ShowFavorites";
		private const string PARM_SHOW_BANNERS = "@ShowBanners";

		public AccountDAO(){
		}

		/// <summary>
		/// Verify the users login credentials against the database
		/// If the user is valid return all information for the user
		/// </summary>
		/// <param name="userId">Username</param>
		/// <param name="password">password</param>
		/// <returns></returns>
		public AccountInfo SignIn(string userId, string password) {

            //SqlParameter[] signOnParms = GetSignOnParameters();

            //signOnParms[0].Value = userId;
            //signOnParms[1].Value = password;

            //using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_ACCOUNT, signOnParms)) {
            //	if (rdr.Read()) {
            //		AddressInfo myAddress = new AddressInfo(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9));
            //		return new AccountInfo(userId, password, rdr.GetString(0), myAddress, rdr.GetString(10), rdr.GetString(11), Convert.ToBoolean(rdr.GetInt32(12)), Convert.ToBoolean(rdr.GetInt32(13))); 
            //	}
            //	return null;
            //}
            var q = (from a in db.Accounts join p in db.Profiles on a.UserId equals p.UserId join s in db.SignOns on a.UserId equals s.UserName where a.UserId == userId && s.Password == password select new { a.Email, a.FirstName, a.LastName, a.Addr1, a.Addr2, a.City, a.State, a.Zip, a.Country, a.Phone, p.LangPref, p.FavCategory, p.MyListOpt, p.BannerOpt }).FirstOrDefault();
            if (q == null)
                return null;
            AddressInfo myAddress = new AddressInfo(q.FirstName, q.LastName, q.Addr1, q.Addr2, q.City, q.State, q.Zip, q.Country, q.Phone);
            return new AccountInfo(userId, password, q.Email, myAddress, q.LangPref, q.FavCategory, q.MyListOpt==1, q.BannerOpt==1) ;
		}

		/// <summary>
		/// Return the address information for a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public AddressInfo GetAddress(string userId) {
            //AddressInfo address= null;

            //SqlParameter[] addressParms = GetAddressParameters();

            //addressParms[0].Value = userId;

            //using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_ADDRESS, addressParms)) {
            //	if (rdr.Read()) {					
            //		address = new AddressInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8)); 					
            //	}
            //}

            //return address;
            return db.Accounts.Where(a => a.UserId == userId).Select(a => new AddressInfo(a.FirstName, a.LastName, a.Addr1, a.Addr2, a.City, a.State, a.Zip, a.Country, a.Phone)).FirstOrDefault();
		}

		/// <summary>
		/// Insert a new account info the database
		/// </summary>
		/// <param name="acc">A thin data class containing all the new account information</param>
		public void Insert(AccountInfo acc) {
            //SqlParameter[] signOnParms = GetSignOnParameters();
            //SqlParameter[] accountParms = GetAccountParameters();
            //SqlParameter[] profileParms = GetProfileParameters();

            //signOnParms[0].Value = acc.UserId;
            //signOnParms[1].Value = acc.Password;

            //SetAccountParameters(accountParms, acc);
            //SetProfileParameters(profileParms, acc);

            //using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING_NON_DTC)) {
            //	conn.Open();
            //	using (SqlTransaction trans = conn.BeginTransaction()) {
            //		try {
            //			SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_SIGNON, signOnParms);
            //			SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_ACCOUNT, accountParms);
            //			SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_PROFILE, profileParms);
            //			trans.Commit();

            //		}catch {
            //			trans.Rollback();
            //			throw;
            //		}
            //	}
            //}
            SignOn signon = new SignOn { UserName = acc.UserId, Password = acc.Password };
            db.SignOns.Add(signon);
            Account account = new Account { UserId = acc.UserId, FirstName = acc.Address.FirstName, LastName = acc.Address.LastName, Email = acc.Email, Addr1 = acc.Address.Address1, Addr2 = acc.Address.Address2, City = acc.Address.City, Country = acc.Address.Country, Phone = acc.Address.Phone, Zip = acc.Address.Zip, State = acc.Address.State };
            db.Accounts.Add(account);
            Profile profile = new Profile { UserId = acc.UserId, LangPref = acc.Language, FavCategory = acc.Category, MyListOpt = acc.IsShowFavorites ? 1 : 0, BannerOpt = acc.IsShowBanners ? 1 : 0 };
            db.Profiles.Add(profile);

            db.SaveChanges();
		}

		/// <summary>
		/// Update an account in the database
		/// </summary>
		/// <param name="myAccount">Updated account parameters, you must supply all parameters</param>
		public void Update(AccountInfo myAccount) {
            //SqlParameter[] accountParms = GetAccountParameters();
            //SqlParameter[] profileParms = GetProfileParameters();

            //SetAccountParameters(accountParms, myAccount);
            //SetProfileParameters(profileParms, myAccount);

            //using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING_NON_DTC)) {
            //	conn.Open();
            //	using (SqlTransaction trans = conn.BeginTransaction()) {
            //		try {
            //			SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_ACCOUNT, accountParms);
            //			SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_PROFILE, profileParms);
            //			trans.Commit();
            //		}catch {
            //			trans.Rollback();
            //			throw;
            //		}
            //	}
            //}
            Account account = new Account { UserId = myAccount.UserId, Email = myAccount.Email, FirstName = myAccount.Address.FirstName, LastName = myAccount.Address.LastName, Addr1 = myAccount.Address.Address1, Addr2 = myAccount.Address.Address2, City = myAccount.Address.City, State = myAccount.Address.State, Zip = myAccount.Address.Zip, Country = myAccount.Address.Country, Phone = myAccount.Address.Phone };
            db.Entry(account).State = EntityState.Modified;

            Profile profile = new Profile { UserId = myAccount.UserId, LangPref = myAccount.Language, FavCategory = myAccount.Category, MyListOpt = myAccount.IsShowFavorites ? 1 : 0, BannerOpt = myAccount.IsShowBanners ? 1 : 0 };
            db.Entry(profile).State = EntityState.Modified;

            db.SaveChanges();
		}



	}
}

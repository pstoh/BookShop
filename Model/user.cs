using System;
namespace BookShop.Model
{
	/// <summary>
	/// user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class user
	{
		public user()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _loginid;
		private string _password;
		private string _email;
		private string _address;
		private string _phone;
		private string _code;
		private int? _state;
		private userstate userState = new userstate();
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginID
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		//public int? state
		//{
			//set{ _state=value;}
			//get{return _state;}
		//}

		public userstate State
		{
			get { return userState; }

			set { userState = value; }
		}
		#endregion Model

	}
}


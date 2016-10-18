using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Update
{
	/// <summary>
    /// HTTP style headers;
	/// </summary>
	public class Headers
	{
		
		/// <summary>
		/// ���header;
		/// </summary>
		public void Add (string name, string value)
		{
			GetAll (name).Add (value);
		}
		
		/// <summary>
		/// ͨ��name ��ȡheader;
		/// </summary>
		public string Get (string name)
		{
			List<string> header = GetAll (name);
			if (header.Count == 0) {
				return "";
			}
			return header [0];
		}
		
		/// <summary>
		/// �Ƿ������name header;
		/// </summary>
		public bool Contains (string name)
		{
			List<string> header = GetAll (name);
			if (header.Count == 0) {
				return false;
			}
			return true;
		}
		
		/// <summary>
		/// ��ȡ��name header ����ֵ;
		/// </summary>
		public List<string> GetAll (string name)
		{
			foreach (string key in headers.Keys) {
				if (string.Compare (name, key, true) == 0) {
					return headers [key];
				}
			}
			List<string> newHeader = new List<string> ();
			headers.Add (name, newHeader);
			return newHeader;
		}
		
		/// <summary>
		/// ����name header ����Ψһֵ;
		/// </summary>
		public void Set (string name, string value)
		{
			List<string> header = GetAll (name);
			header.Clear ();
			header.Add (value);
		}
		
		/// <summary>
		/// ��header�б����Ƴ���name header;
		/// </summary>
		public void Pop (string name)
		{
			if (headers.ContainsKey (name)) {
				headers.Remove (name);
			}
		}
		
		
		
		/// <summary>
		/// ��ȡ�����б��е�header nameֵ;
		/// </summary>
		public List<string> Keys {
			get {
				return headers.Keys.ToList();		
			}
		}
		
		/// <summary>
		/// ����б�;
		/// </summary>
		public void Clear() {
			headers.Clear();
		}
	
		Dictionary<string, List<string>> headers = new Dictionary<string, List<string>> ();

        public Hashtable GetHashtable() {
            return new Hashtable(headers);
        }
	}
}
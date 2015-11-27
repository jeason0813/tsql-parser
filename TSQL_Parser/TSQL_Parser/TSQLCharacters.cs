﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQL
{
	public class TSQLCharacters
	{
		private static Dictionary<string, TSQLCharacters> characterLookup =
			new Dictionary<string, TSQLCharacters>(StringComparer.InvariantCultureIgnoreCase);

		public static TSQLCharacters None = new TSQLCharacters(string.Empty);
		public static TSQLCharacters Comma = new TSQLCharacters(",");
		public static TSQLCharacters Semicolon = new TSQLCharacters(";");
		public static TSQLCharacters OpenParentheses = new TSQLCharacters("(");
		public static TSQLCharacters CloseParentheses = new TSQLCharacters(")");
		public static TSQLCharacters Space = new TSQLCharacters(" ");
		public static TSQLCharacters Tab = new TSQLCharacters("\t");
		public static TSQLCharacters CarriageReturn = new TSQLCharacters("\r");
		public static TSQLCharacters LineFeed = new TSQLCharacters("\n");
		public static TSQLCharacters Period = new TSQLCharacters(".");

		private string Token;

		private TSQLCharacters(
			string token)
		{
			Token = token;
			if (token.Length > 0)
			{
				characterLookup[token] = this;
			}
		}

		public static TSQLCharacters Parse(
			string token)
		{
			if (
				!string.IsNullOrEmpty(token) &&
				characterLookup.ContainsKey(token))
			{
				return characterLookup[token];
			}
			else
			{
				return TSQLCharacters.None;
			}
		}

		public static bool IsCharacter(
			string token)
		{
			if (!string.IsNullOrWhiteSpace(token))
			{
				return characterLookup.ContainsKey(token);
			}
			else
			{
				return false;
			}
		}

		public static bool operator ==(
			TSQLCharacters a,
			TSQLCharacters b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(
			TSQLCharacters a,
			TSQLCharacters b)
		{
			return !a.Equals(b);
		}

		public bool Equals(TSQLCharacters obj)
		{
			return Token == obj.Token;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Token.GetHashCode();
		}
	}

}
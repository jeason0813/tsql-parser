﻿using System;

namespace TSQL.Tokens
{
	public class TSQLNumericLiteral : TSQLLiteral
	{
		internal TSQLNumericLiteral(
			int beginPostion,
			string text) :
			base(
				beginPostion,
				text)
		{

		}

#pragma warning disable 1591

		public override TSQLTokenType Type
		{
			get
			{
				return TSQLTokenType.NumericLiteral;
			}
		}

#pragma warning restore 1591
	}
}

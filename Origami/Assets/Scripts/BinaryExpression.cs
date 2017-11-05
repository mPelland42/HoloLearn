using System.Collections;
using System;

public class BinaryExpression {
	private double rawValue;
	private char operato;
	private BinaryExpression left;
	private BinaryExpression right;
	private ArrayList opers = new ArrayList();
	private static bool hasTopLevelParen(string s) {
		int parenLevel = 0;
		for(int i = 0; i < s.Length; i++) {
			char ch = s.ToCharArray() [i];
			if(ch == '(') {
				parenLevel++;
			} else if(ch == ')') {
				parenLevel--;
			} else if(parenLevel == 0) {
				return true;
			}
		}
		return false;
	}
	private int splitPoint(string s) {
		int parenLevel = 0;
		int bestIndex = -1;
		int bestLoc = 0;
		for(int i = s.Length - 1; i >= 0; i--) {
			char ch = s.ToCharArray ()[i];

			if(ch == '(') {
				parenLevel++;
			} else if(ch == ')') {
				parenLevel--;
			} else if(parenLevel == 0) {
				if(opers.Contains(ch) && (opers.IndexOf(ch) + 1) / 2 > bestIndex) {
					bestIndex = opers.IndexOf(ch) / 2;
					bestLoc = i;
				}
			}
		}
		return bestLoc;
	}
	public BinaryExpression(string s) {
		s = s.Trim ();
		if(!hasTopLevelParen(s)) {
			s = s.Substring(s.IndexOf('(') + 1, s.LastIndexOf(')'));
		}
		if(s.Equals("x") || s.Equals("y")) {
			operato = s.ToCharArray()[0];
			return;
		}
		if (double.TryParse(s, out rawValue)) {
			operato = 'r';
		} else {
			opers.Add('^');
			opers.Add('*');
			opers.Add('/');
			opers.Add('+');
			opers.Add('-');



			left = new BinaryExpression(s.Substring(0, splitPoint(s)));
			right = new BinaryExpression(s.Substring(splitPoint(s) + 1));
			operato = s.ToCharArray()[splitPoint(s)];
		}
	}
	public double evaluate(double x, double y) {
		switch(operato) {
		case 'r':
			return rawValue;
		case '+':
			return left.evaluate(x, y) + right.evaluate(x, y);
		case '-':
			return left.evaluate(x, y) - right.evaluate(x, y);
		case '/':
			return left.evaluate(x, y) / right.evaluate(x, y);
		case '*':
			return left.evaluate(x, y) * right.evaluate(x, y);
		case '^':
			return System.Math.Pow(left.evaluate(x, y),right.evaluate(x, y));
		case 'x':
			return x;
		case 'y':
			return y;
		default:
			return 0;
		}
	}


}
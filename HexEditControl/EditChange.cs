﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zodiacon.HexEditControl {
	public sealed class EditChange : IEqualityComparer<EditChange>, IComparable<EditChange> {
		public EditChange(long offset, params byte[] data) {
			Offset = offset;
			if (data != null)
				Data = new List<byte>(data);
			else
				Data = new List<byte>(32);
		}

		public long Offset { get; private set; }
		public List<byte> Data { get; }

		public bool Overwrite { get; set; }
		public int Size => Data.Count;

		public int CompareTo(EditChange other) {
			return Offset.CompareTo(other.Offset);
		}

		public bool Equals(EditChange x, EditChange y) {
			return x.Offset == y.Offset;
		}

		public int GetHashCode(EditChange obj) {
			return obj.Offset.GetHashCode();
		}

		public void UpdateOffset(int delta) {
			Offset += delta;
		}

		public bool Intersect(long offset, int size) {
			return offset >= Offset && offset + size <= Offset + Size;
		}
	}

}
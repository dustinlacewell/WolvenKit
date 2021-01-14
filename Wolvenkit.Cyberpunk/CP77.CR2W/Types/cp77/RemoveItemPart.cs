using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class RemoveItemPart : gameScriptableSystemRequest
	{
		[Ordinal(0)]  [RED("baseItem")] public gameItemID BaseItem { get; set; }
		[Ordinal(1)]  [RED("obj")] public wCHandle<gameObject> Obj { get; set; }
		[Ordinal(2)]  [RED("slotToEmpty")] public TweakDBID SlotToEmpty { get; set; }

		public RemoveItemPart(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
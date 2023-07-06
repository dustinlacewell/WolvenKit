using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	public partial class workWorkEntryId : RedBaseClass
	{
		[Ordinal(0)] 
		[RED("id")] 
		public CUInt32 Id
		{
			get => GetPropertyValue<CUInt32>();
			set => SetPropertyValue<CUInt32>(value);
		}

		public workWorkEntryId()
		{
			Id = uint.MaxValue;

			PostConstruct();
		}

		partial void PostConstruct();
	}
}

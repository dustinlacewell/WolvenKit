using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	public partial class InventoryWeaponDisplayController : InventoryItemDisplayController
	{
		[Ordinal(120)] 
		[RED("weaponSpecyficModsRoot")] 
		public inkCompoundWidgetReference WeaponSpecyficModsRoot
		{
			get => GetPropertyValue<inkCompoundWidgetReference>();
			set => SetPropertyValue<inkCompoundWidgetReference>(value);
		}

		[Ordinal(121)] 
		[RED("silencerIcon")] 
		public inkWidgetReference SilencerIcon
		{
			get => GetPropertyValue<inkWidgetReference>();
			set => SetPropertyValue<inkWidgetReference>(value);
		}

		[Ordinal(122)] 
		[RED("scopeIcon")] 
		public inkWidgetReference ScopeIcon
		{
			get => GetPropertyValue<inkWidgetReference>();
			set => SetPropertyValue<inkWidgetReference>(value);
		}

		[Ordinal(123)] 
		[RED("ammoIcon")] 
		public inkImageWidgetReference AmmoIcon
		{
			get => GetPropertyValue<inkImageWidgetReference>();
			set => SetPropertyValue<inkImageWidgetReference>(value);
		}

		[Ordinal(124)] 
		[RED("weaponAttachmentsDisplay")] 
		public CArray<CWeakHandle<InventoryItemPartDisplay>> WeaponAttachmentsDisplay
		{
			get => GetPropertyValue<CArray<CWeakHandle<InventoryItemPartDisplay>>>();
			set => SetPropertyValue<CArray<CWeakHandle<InventoryItemPartDisplay>>>(value);
		}

		public InventoryWeaponDisplayController()
		{
			WeaponSpecyficModsRoot = new inkCompoundWidgetReference();
			SilencerIcon = new inkWidgetReference();
			ScopeIcon = new inkWidgetReference();
			AmmoIcon = new inkImageWidgetReference();
			WeaponAttachmentsDisplay = new();

			PostConstruct();
		}

		partial void PostConstruct();
	}
}

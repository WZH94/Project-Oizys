using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0]")]
	public partial class CampfireSpotNetworkObject : NetworkObject
	{
		public const int IDENTITY = 1;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private bool _spotTaken;
		public event FieldEvent<bool> spotTakenChanged;
		public Interpolated<bool> spotTakenInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool spotTaken
		{
			get { return _spotTaken; }
			set
			{
				// Don't do anything if the value is the same
				if (_spotTaken == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_spotTaken = value;
				hasDirtyFields = true;
			}
		}

		public void SetspotTakenDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_spotTaken(ulong timestep)
		{
			if (spotTakenChanged != null) spotTakenChanged(_spotTaken, timestep);
			if (fieldAltered != null) fieldAltered("spotTaken", _spotTaken, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			spotTakenInterpolation.current = spotTakenInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _spotTaken);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_spotTaken = UnityObjectMapper.Instance.Map<bool>(payload);
			spotTakenInterpolation.current = _spotTaken;
			spotTakenInterpolation.target = _spotTaken;
			RunChange_spotTaken(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _spotTaken);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (spotTakenInterpolation.Enabled)
				{
					spotTakenInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					spotTakenInterpolation.Timestep = timestep;
				}
				else
				{
					_spotTaken = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_spotTaken(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (spotTakenInterpolation.Enabled && !spotTakenInterpolation.current.UnityNear(spotTakenInterpolation.target, 0.0015f))
			{
				_spotTaken = (bool)spotTakenInterpolation.Interpolate();
				//RunChange_spotTaken(spotTakenInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public CampfireSpotNetworkObject() : base() { Initialize(); }
		public CampfireSpotNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public CampfireSpotNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}

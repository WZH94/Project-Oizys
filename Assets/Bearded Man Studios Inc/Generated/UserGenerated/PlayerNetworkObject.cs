using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0,0,0]")]
	public partial class PlayerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 10;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0.15f, Enabled = true };
		public Vector3 position
		{
			get { return _position; }
			set
			{
				// Don't do anything if the value is the same
				if (_position == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_position = value;
				hasDirtyFields = true;
			}
		}

		public void SetpositionDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_position(ulong timestep)
		{
			if (positionChanged != null) positionChanged(_position, timestep);
			if (fieldAltered != null) fieldAltered("position", _position, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rotation;
		public event FieldEvent<Quaternion> rotationChanged;
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion rotation
		{
			get { return _rotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_rotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_rotation(ulong timestep)
		{
			if (rotationChanged != null) rotationChanged(_rotation, timestep);
			if (fieldAltered != null) fieldAltered("rotation", _rotation, timestep);
		}
		[ForgeGeneratedField]
		private bool _walking;
		public event FieldEvent<bool> walkingChanged;
		public Interpolated<bool> walkingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool walking
		{
			get { return _walking; }
			set
			{
				// Don't do anything if the value is the same
				if (_walking == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_walking = value;
				hasDirtyFields = true;
			}
		}

		public void SetwalkingDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_walking(ulong timestep)
		{
			if (walkingChanged != null) walkingChanged(_walking, timestep);
			if (fieldAltered != null) fieldAltered("walking", _walking, timestep);
		}
		[ForgeGeneratedField]
		private bool _seating;
		public event FieldEvent<bool> seatingChanged;
		public Interpolated<bool> seatingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool seating
		{
			get { return _seating; }
			set
			{
				// Don't do anything if the value is the same
				if (_seating == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_seating = value;
				hasDirtyFields = true;
			}
		}

		public void SetseatingDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_seating(ulong timestep)
		{
			if (seatingChanged != null) seatingChanged(_seating, timestep);
			if (fieldAltered != null) fieldAltered("seating", _seating, timestep);
		}
		[ForgeGeneratedField]
		private float _controllerCenterY;
		public event FieldEvent<float> controllerCenterYChanged;
		public InterpolateFloat controllerCenterYInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float controllerCenterY
		{
			get { return _controllerCenterY; }
			set
			{
				// Don't do anything if the value is the same
				if (_controllerCenterY == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_controllerCenterY = value;
				hasDirtyFields = true;
			}
		}

		public void SetcontrollerCenterYDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_controllerCenterY(ulong timestep)
		{
			if (controllerCenterYChanged != null) controllerCenterYChanged(_controllerCenterY, timestep);
			if (fieldAltered != null) fieldAltered("controllerCenterY", _controllerCenterY, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			positionInterpolation.current = positionInterpolation.target;
			rotationInterpolation.current = rotationInterpolation.target;
			walkingInterpolation.current = walkingInterpolation.target;
			seatingInterpolation.current = seatingInterpolation.target;
			controllerCenterYInterpolation.current = controllerCenterYInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _walking);
			UnityObjectMapper.Instance.MapBytes(data, _seating);
			UnityObjectMapper.Instance.MapBytes(data, _controllerCenterY);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_position = UnityObjectMapper.Instance.Map<Vector3>(payload);
			positionInterpolation.current = _position;
			positionInterpolation.target = _position;
			RunChange_position(timestep);
			_rotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rotationInterpolation.current = _rotation;
			rotationInterpolation.target = _rotation;
			RunChange_rotation(timestep);
			_walking = UnityObjectMapper.Instance.Map<bool>(payload);
			walkingInterpolation.current = _walking;
			walkingInterpolation.target = _walking;
			RunChange_walking(timestep);
			_seating = UnityObjectMapper.Instance.Map<bool>(payload);
			seatingInterpolation.current = _seating;
			seatingInterpolation.target = _seating;
			RunChange_seating(timestep);
			_controllerCenterY = UnityObjectMapper.Instance.Map<float>(payload);
			controllerCenterYInterpolation.current = _controllerCenterY;
			controllerCenterYInterpolation.target = _controllerCenterY;
			RunChange_controllerCenterY(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _position);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _walking);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _seating);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _controllerCenterY);

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
				if (positionInterpolation.Enabled)
				{
					positionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					positionInterpolation.Timestep = timestep;
				}
				else
				{
					_position = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_position(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (rotationInterpolation.Enabled)
				{
					rotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (walkingInterpolation.Enabled)
				{
					walkingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					walkingInterpolation.Timestep = timestep;
				}
				else
				{
					_walking = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_walking(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (seatingInterpolation.Enabled)
				{
					seatingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					seatingInterpolation.Timestep = timestep;
				}
				else
				{
					_seating = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_seating(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (controllerCenterYInterpolation.Enabled)
				{
					controllerCenterYInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					controllerCenterYInterpolation.Timestep = timestep;
				}
				else
				{
					_controllerCenterY = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_controllerCenterY(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (positionInterpolation.Enabled && !positionInterpolation.current.UnityNear(positionInterpolation.target, 0.0015f))
			{
				_position = (Vector3)positionInterpolation.Interpolate();
				//RunChange_position(positionInterpolation.Timestep);
			}
			if (rotationInterpolation.Enabled && !rotationInterpolation.current.UnityNear(rotationInterpolation.target, 0.0015f))
			{
				_rotation = (Quaternion)rotationInterpolation.Interpolate();
				//RunChange_rotation(rotationInterpolation.Timestep);
			}
			if (walkingInterpolation.Enabled && !walkingInterpolation.current.UnityNear(walkingInterpolation.target, 0.0015f))
			{
				_walking = (bool)walkingInterpolation.Interpolate();
				//RunChange_walking(walkingInterpolation.Timestep);
			}
			if (seatingInterpolation.Enabled && !seatingInterpolation.current.UnityNear(seatingInterpolation.target, 0.0015f))
			{
				_seating = (bool)seatingInterpolation.Interpolate();
				//RunChange_seating(seatingInterpolation.Timestep);
			}
			if (controllerCenterYInterpolation.Enabled && !controllerCenterYInterpolation.current.UnityNear(controllerCenterYInterpolation.target, 0.0015f))
			{
				_controllerCenterY = (float)controllerCenterYInterpolation.Interpolate();
				//RunChange_controllerCenterY(controllerCenterYInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public PlayerNetworkObject() : base() { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}

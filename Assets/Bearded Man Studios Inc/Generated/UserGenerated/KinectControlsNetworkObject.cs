using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0.15,0.15,0.15,0.15,0.15]")]
	public partial class KinectControlsNetworkObject : NetworkObject
	{
		public const int IDENTITY = 5;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Quaternion _spineRotation;
		public event FieldEvent<Quaternion> spineRotationChanged;
		public InterpolateQuaternion spineRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion spineRotation
		{
			get { return _spineRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_spineRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_spineRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetspineRotationDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_spineRotation(ulong timestep)
		{
			if (spineRotationChanged != null) spineRotationChanged(_spineRotation, timestep);
			if (fieldAltered != null) fieldAltered("spineRotation", _spineRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _headRotation;
		public event FieldEvent<Quaternion> headRotationChanged;
		public InterpolateQuaternion headRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion headRotation
		{
			get { return _headRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_headRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_headRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetheadRotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_headRotation(ulong timestep)
		{
			if (headRotationChanged != null) headRotationChanged(_headRotation, timestep);
			if (fieldAltered != null) fieldAltered("headRotation", _headRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _neckRotation;
		public event FieldEvent<Quaternion> neckRotationChanged;
		public InterpolateQuaternion neckRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion neckRotation
		{
			get { return _neckRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_neckRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_neckRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetneckRotationDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_neckRotation(ulong timestep)
		{
			if (neckRotationChanged != null) neckRotationChanged(_neckRotation, timestep);
			if (fieldAltered != null) fieldAltered("neckRotation", _neckRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _leftShoulderRotation;
		public event FieldEvent<Quaternion> leftShoulderRotationChanged;
		public InterpolateQuaternion leftShoulderRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion leftShoulderRotation
		{
			get { return _leftShoulderRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_leftShoulderRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_leftShoulderRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetleftShoulderRotationDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_leftShoulderRotation(ulong timestep)
		{
			if (leftShoulderRotationChanged != null) leftShoulderRotationChanged(_leftShoulderRotation, timestep);
			if (fieldAltered != null) fieldAltered("leftShoulderRotation", _leftShoulderRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _leftElbowRotation;
		public event FieldEvent<Quaternion> leftElbowRotationChanged;
		public InterpolateQuaternion leftElbowRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion leftElbowRotation
		{
			get { return _leftElbowRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_leftElbowRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_leftElbowRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetleftElbowRotationDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_leftElbowRotation(ulong timestep)
		{
			if (leftElbowRotationChanged != null) leftElbowRotationChanged(_leftElbowRotation, timestep);
			if (fieldAltered != null) fieldAltered("leftElbowRotation", _leftElbowRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rightShoulderRotation;
		public event FieldEvent<Quaternion> rightShoulderRotationChanged;
		public InterpolateQuaternion rightShoulderRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion rightShoulderRotation
		{
			get { return _rightShoulderRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rightShoulderRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_rightShoulderRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrightShoulderRotationDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_rightShoulderRotation(ulong timestep)
		{
			if (rightShoulderRotationChanged != null) rightShoulderRotationChanged(_rightShoulderRotation, timestep);
			if (fieldAltered != null) fieldAltered("rightShoulderRotation", _rightShoulderRotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rightElbowRotation;
		public event FieldEvent<Quaternion> rightElbowRotationChanged;
		public InterpolateQuaternion rightElbowRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion rightElbowRotation
		{
			get { return _rightElbowRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rightElbowRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x40;
				_rightElbowRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrightElbowRotationDirty()
		{
			_dirtyFields[0] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_rightElbowRotation(ulong timestep)
		{
			if (rightElbowRotationChanged != null) rightElbowRotationChanged(_rightElbowRotation, timestep);
			if (fieldAltered != null) fieldAltered("rightElbowRotation", _rightElbowRotation, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			spineRotationInterpolation.current = spineRotationInterpolation.target;
			headRotationInterpolation.current = headRotationInterpolation.target;
			neckRotationInterpolation.current = neckRotationInterpolation.target;
			leftShoulderRotationInterpolation.current = leftShoulderRotationInterpolation.target;
			leftElbowRotationInterpolation.current = leftElbowRotationInterpolation.target;
			rightShoulderRotationInterpolation.current = rightShoulderRotationInterpolation.target;
			rightElbowRotationInterpolation.current = rightElbowRotationInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _spineRotation);
			UnityObjectMapper.Instance.MapBytes(data, _headRotation);
			UnityObjectMapper.Instance.MapBytes(data, _neckRotation);
			UnityObjectMapper.Instance.MapBytes(data, _leftShoulderRotation);
			UnityObjectMapper.Instance.MapBytes(data, _leftElbowRotation);
			UnityObjectMapper.Instance.MapBytes(data, _rightShoulderRotation);
			UnityObjectMapper.Instance.MapBytes(data, _rightElbowRotation);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_spineRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			spineRotationInterpolation.current = _spineRotation;
			spineRotationInterpolation.target = _spineRotation;
			RunChange_spineRotation(timestep);
			_headRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			headRotationInterpolation.current = _headRotation;
			headRotationInterpolation.target = _headRotation;
			RunChange_headRotation(timestep);
			_neckRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			neckRotationInterpolation.current = _neckRotation;
			neckRotationInterpolation.target = _neckRotation;
			RunChange_neckRotation(timestep);
			_leftShoulderRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			leftShoulderRotationInterpolation.current = _leftShoulderRotation;
			leftShoulderRotationInterpolation.target = _leftShoulderRotation;
			RunChange_leftShoulderRotation(timestep);
			_leftElbowRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			leftElbowRotationInterpolation.current = _leftElbowRotation;
			leftElbowRotationInterpolation.target = _leftElbowRotation;
			RunChange_leftElbowRotation(timestep);
			_rightShoulderRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rightShoulderRotationInterpolation.current = _rightShoulderRotation;
			rightShoulderRotationInterpolation.target = _rightShoulderRotation;
			RunChange_rightShoulderRotation(timestep);
			_rightElbowRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rightElbowRotationInterpolation.current = _rightElbowRotation;
			rightElbowRotationInterpolation.target = _rightElbowRotation;
			RunChange_rightElbowRotation(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _spineRotation);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _headRotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _neckRotation);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _leftShoulderRotation);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _leftElbowRotation);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rightShoulderRotation);
			if ((0x40 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rightElbowRotation);

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
				if (spineRotationInterpolation.Enabled)
				{
					spineRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					spineRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_spineRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_spineRotation(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (headRotationInterpolation.Enabled)
				{
					headRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					headRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_headRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_headRotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (neckRotationInterpolation.Enabled)
				{
					neckRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					neckRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_neckRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_neckRotation(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (leftShoulderRotationInterpolation.Enabled)
				{
					leftShoulderRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					leftShoulderRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_leftShoulderRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_leftShoulderRotation(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (leftElbowRotationInterpolation.Enabled)
				{
					leftElbowRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					leftElbowRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_leftElbowRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_leftElbowRotation(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (rightShoulderRotationInterpolation.Enabled)
				{
					rightShoulderRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rightShoulderRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rightShoulderRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rightShoulderRotation(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[0]) != 0)
			{
				if (rightElbowRotationInterpolation.Enabled)
				{
					rightElbowRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rightElbowRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rightElbowRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rightElbowRotation(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (spineRotationInterpolation.Enabled && !spineRotationInterpolation.current.UnityNear(spineRotationInterpolation.target, 0.0015f))
			{
				_spineRotation = (Quaternion)spineRotationInterpolation.Interpolate();
				//RunChange_spineRotation(spineRotationInterpolation.Timestep);
			}
			if (headRotationInterpolation.Enabled && !headRotationInterpolation.current.UnityNear(headRotationInterpolation.target, 0.0015f))
			{
				_headRotation = (Quaternion)headRotationInterpolation.Interpolate();
				//RunChange_headRotation(headRotationInterpolation.Timestep);
			}
			if (neckRotationInterpolation.Enabled && !neckRotationInterpolation.current.UnityNear(neckRotationInterpolation.target, 0.0015f))
			{
				_neckRotation = (Quaternion)neckRotationInterpolation.Interpolate();
				//RunChange_neckRotation(neckRotationInterpolation.Timestep);
			}
			if (leftShoulderRotationInterpolation.Enabled && !leftShoulderRotationInterpolation.current.UnityNear(leftShoulderRotationInterpolation.target, 0.0015f))
			{
				_leftShoulderRotation = (Quaternion)leftShoulderRotationInterpolation.Interpolate();
				//RunChange_leftShoulderRotation(leftShoulderRotationInterpolation.Timestep);
			}
			if (leftElbowRotationInterpolation.Enabled && !leftElbowRotationInterpolation.current.UnityNear(leftElbowRotationInterpolation.target, 0.0015f))
			{
				_leftElbowRotation = (Quaternion)leftElbowRotationInterpolation.Interpolate();
				//RunChange_leftElbowRotation(leftElbowRotationInterpolation.Timestep);
			}
			if (rightShoulderRotationInterpolation.Enabled && !rightShoulderRotationInterpolation.current.UnityNear(rightShoulderRotationInterpolation.target, 0.0015f))
			{
				_rightShoulderRotation = (Quaternion)rightShoulderRotationInterpolation.Interpolate();
				//RunChange_rightShoulderRotation(rightShoulderRotationInterpolation.Timestep);
			}
			if (rightElbowRotationInterpolation.Enabled && !rightElbowRotationInterpolation.current.UnityNear(rightElbowRotationInterpolation.target, 0.0015f))
			{
				_rightElbowRotation = (Quaternion)rightElbowRotationInterpolation.Interpolate();
				//RunChange_rightElbowRotation(rightElbowRotationInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public KinectControlsNetworkObject() : base() { Initialize(); }
		public KinectControlsNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public KinectControlsNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}

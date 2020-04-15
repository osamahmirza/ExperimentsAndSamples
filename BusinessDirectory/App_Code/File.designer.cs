﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GOPROGO")]
public partial class FileDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InserttblFileExtension(tblFileExtension instance);
  partial void UpdatetblFileExtension(tblFileExtension instance);
  partial void DeletetblFileExtension(tblFileExtension instance);
  partial void InserttlkpFileExtensionType(tlkpFileExtensionType instance);
  partial void UpdatetlkpFileExtensionType(tlkpFileExtensionType instance);
  partial void DeletetlkpFileExtensionType(tlkpFileExtensionType instance);
  partial void InserttblFileInformation(tblFileInformation instance);
  partial void UpdatetblFileInformation(tblFileInformation instance);
  partial void DeletetblFileInformation(tblFileInformation instance);
  partial void InserttlkpAccessType(tlkpAccessType instance);
  partial void UpdatetlkpAccessType(tlkpAccessType instance);
  partial void DeletetlkpAccessType(tlkpAccessType instance);
  #endregion
	
	public FileDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GOPROGOConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public FileDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FileDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FileDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FileDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<tblFileExtension> tblFileExtensions
	{
		get
		{
			return this.GetTable<tblFileExtension>();
		}
	}
	
	public System.Data.Linq.Table<tlkpFileExtensionType> tlkpFileExtensionTypes
	{
		get
		{
			return this.GetTable<tlkpFileExtensionType>();
		}
	}
	
	public System.Data.Linq.Table<tblFileInformation> tblFileInformations
	{
		get
		{
			return this.GetTable<tblFileInformation>();
		}
	}
	
	public System.Data.Linq.Table<tlkpAccessType> tlkpAccessTypes
	{
		get
		{
			return this.GetTable<tlkpAccessType>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="[FILE].tblFileExtension")]
public partial class tblFileExtension : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _Name;
	
	private string _ContentType;
	
	private System.Nullable<int> _FileExtensionTypeID;
	
	private EntitySet<tblFileInformation> _tblFileInformations;
	
	private EntityRef<tlkpFileExtensionType> _tlkpFileExtensionType;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnContentTypeChanging(string value);
    partial void OnContentTypeChanged();
    partial void OnFileExtensionTypeIDChanging(System.Nullable<int> value);
    partial void OnFileExtensionTypeIDChanged();
    #endregion
	
	public tblFileExtension()
	{
		this._tblFileInformations = new EntitySet<tblFileInformation>(new Action<tblFileInformation>(this.attach_tblFileInformations), new Action<tblFileInformation>(this.detach_tblFileInformations));
		this._tlkpFileExtensionType = default(EntityRef<tlkpFileExtensionType>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContentType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string ContentType
	{
		get
		{
			return this._ContentType;
		}
		set
		{
			if ((this._ContentType != value))
			{
				this.OnContentTypeChanging(value);
				this.SendPropertyChanging();
				this._ContentType = value;
				this.SendPropertyChanged("ContentType");
				this.OnContentTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileExtensionTypeID", DbType="Int")]
	public System.Nullable<int> FileExtensionTypeID
	{
		get
		{
			return this._FileExtensionTypeID;
		}
		set
		{
			if ((this._FileExtensionTypeID != value))
			{
				if (this._tlkpFileExtensionType.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnFileExtensionTypeIDChanging(value);
				this.SendPropertyChanging();
				this._FileExtensionTypeID = value;
				this.SendPropertyChanged("FileExtensionTypeID");
				this.OnFileExtensionTypeIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblFileExtension_tblFileInformation", Storage="_tblFileInformations", ThisKey="ID", OtherKey="FileExtensionID")]
	public EntitySet<tblFileInformation> tblFileInformations
	{
		get
		{
			return this._tblFileInformations;
		}
		set
		{
			this._tblFileInformations.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tlkpFileExtensionType_tblFileExtension", Storage="_tlkpFileExtensionType", ThisKey="FileExtensionTypeID", OtherKey="ID", IsForeignKey=true)]
	public tlkpFileExtensionType tlkpFileExtensionType
	{
		get
		{
			return this._tlkpFileExtensionType.Entity;
		}
		set
		{
			tlkpFileExtensionType previousValue = this._tlkpFileExtensionType.Entity;
			if (((previousValue != value) 
						|| (this._tlkpFileExtensionType.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._tlkpFileExtensionType.Entity = null;
					previousValue.tblFileExtensions.Remove(this);
				}
				this._tlkpFileExtensionType.Entity = value;
				if ((value != null))
				{
					value.tblFileExtensions.Add(this);
					this._FileExtensionTypeID = value.ID;
				}
				else
				{
					this._FileExtensionTypeID = default(Nullable<int>);
				}
				this.SendPropertyChanged("tlkpFileExtensionType");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tblFileExtension = this;
	}
	
	private void detach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tblFileExtension = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="[FILE].tlkpFileExtensionType")]
public partial class tlkpFileExtensionType : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _Name;
	
	private EntitySet<tblFileExtension> _tblFileExtensions;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
	
	public tlkpFileExtensionType()
	{
		this._tblFileExtensions = new EntitySet<tblFileExtension>(new Action<tblFileExtension>(this.attach_tblFileExtensions), new Action<tblFileExtension>(this.detach_tblFileExtensions));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(6) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tlkpFileExtensionType_tblFileExtension", Storage="_tblFileExtensions", ThisKey="ID", OtherKey="FileExtensionTypeID")]
	public EntitySet<tblFileExtension> tblFileExtensions
	{
		get
		{
			return this._tblFileExtensions;
		}
		set
		{
			this._tblFileExtensions.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_tblFileExtensions(tblFileExtension entity)
	{
		this.SendPropertyChanging();
		entity.tlkpFileExtensionType = this;
	}
	
	private void detach_tblFileExtensions(tblFileExtension entity)
	{
		this.SendPropertyChanging();
		entity.tlkpFileExtensionType = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="[FILE].tblFileInformation")]
public partial class tblFileInformation : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _PhysicalFileName;
	
	private string _Path;
	
	private int _FileExtensionID;
	
	private System.Nullable<int> _ParentID;
	
	private System.Nullable<int> _ProfileID;
	
	private long _ContentLength;
	
	private int _AccessTypeID;
	
	private System.Nullable<System.DateTime> _CreatedDate;
	
	private string _FullPath;
	
	private EntitySet<tblFileInformation> _tblFileInformations;
	
	private EntityRef<tblFileExtension> _tblFileExtension;
	
	private EntityRef<tblFileInformation> _tblFileInformation1;
	
	private EntityRef<tlkpAccessType> _tlkpAccessType;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPhysicalFileNameChanging(string value);
    partial void OnPhysicalFileNameChanged();
    partial void OnPathChanging(string value);
    partial void OnPathChanged();
    partial void OnFileExtensionIDChanging(int value);
    partial void OnFileExtensionIDChanged();
    partial void OnParentIDChanging(System.Nullable<int> value);
    partial void OnParentIDChanged();
    partial void OnProfileIDChanging(System.Nullable<int> value);
    partial void OnProfileIDChanged();
    partial void OnContentLengthChanging(long value);
    partial void OnContentLengthChanged();
    partial void OnAccessTypeIDChanging(int value);
    partial void OnAccessTypeIDChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnFullPathChanging(string value);
    partial void OnFullPathChanged();
    #endregion
	
	public tblFileInformation()
	{
		this._tblFileInformations = new EntitySet<tblFileInformation>(new Action<tblFileInformation>(this.attach_tblFileInformations), new Action<tblFileInformation>(this.detach_tblFileInformations));
		this._tblFileExtension = default(EntityRef<tblFileExtension>);
		this._tblFileInformation1 = default(EntityRef<tblFileInformation>);
		this._tlkpAccessType = default(EntityRef<tlkpAccessType>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhysicalFileName", DbType="VarChar(512) NOT NULL", CanBeNull=false)]
	public string PhysicalFileName
	{
		get
		{
			return this._PhysicalFileName;
		}
		set
		{
			if ((this._PhysicalFileName != value))
			{
				this.OnPhysicalFileNameChanging(value);
				this.SendPropertyChanging();
				this._PhysicalFileName = value;
				this.SendPropertyChanged("PhysicalFileName");
				this.OnPhysicalFileNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Path", DbType="VarChar(1024) NOT NULL", CanBeNull=false)]
	public string Path
	{
		get
		{
			return this._Path;
		}
		set
		{
			if ((this._Path != value))
			{
				this.OnPathChanging(value);
				this.SendPropertyChanging();
				this._Path = value;
				this.SendPropertyChanged("Path");
				this.OnPathChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileExtensionID", DbType="Int NOT NULL")]
	public int FileExtensionID
	{
		get
		{
			return this._FileExtensionID;
		}
		set
		{
			if ((this._FileExtensionID != value))
			{
				if (this._tblFileExtension.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnFileExtensionIDChanging(value);
				this.SendPropertyChanging();
				this._FileExtensionID = value;
				this.SendPropertyChanged("FileExtensionID");
				this.OnFileExtensionIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentID", DbType="Int")]
	public System.Nullable<int> ParentID
	{
		get
		{
			return this._ParentID;
		}
		set
		{
			if ((this._ParentID != value))
			{
				if (this._tblFileInformation1.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnParentIDChanging(value);
				this.SendPropertyChanging();
				this._ParentID = value;
				this.SendPropertyChanged("ParentID");
				this.OnParentIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProfileID", DbType="Int")]
	public System.Nullable<int> ProfileID
	{
		get
		{
			return this._ProfileID;
		}
		set
		{
			if ((this._ProfileID != value))
			{
				this.OnProfileIDChanging(value);
				this.SendPropertyChanging();
				this._ProfileID = value;
				this.SendPropertyChanged("ProfileID");
				this.OnProfileIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContentLength", DbType="BigInt NOT NULL")]
	public long ContentLength
	{
		get
		{
			return this._ContentLength;
		}
		set
		{
			if ((this._ContentLength != value))
			{
				this.OnContentLengthChanging(value);
				this.SendPropertyChanging();
				this._ContentLength = value;
				this.SendPropertyChanged("ContentLength");
				this.OnContentLengthChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessTypeID", DbType="Int NOT NULL")]
	public int AccessTypeID
	{
		get
		{
			return this._AccessTypeID;
		}
		set
		{
			if ((this._AccessTypeID != value))
			{
				if (this._tlkpAccessType.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnAccessTypeIDChanging(value);
				this.SendPropertyChanging();
				this._AccessTypeID = value;
				this.SendPropertyChanged("AccessTypeID");
				this.OnAccessTypeIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedDate
	{
		get
		{
			return this._CreatedDate;
		}
		set
		{
			if ((this._CreatedDate != value))
			{
				this.OnCreatedDateChanging(value);
				this.SendPropertyChanging();
				this._CreatedDate = value;
				this.SendPropertyChanged("CreatedDate");
				this.OnCreatedDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullPath", DbType="VarChar(1536)")]
	public string FullPath
	{
		get
		{
			return this._FullPath;
		}
		set
		{
			if ((this._FullPath != value))
			{
				this.OnFullPathChanging(value);
				this.SendPropertyChanging();
				this._FullPath = value;
				this.SendPropertyChanged("FullPath");
				this.OnFullPathChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblFileInformation_tblFileInformation", Storage="_tblFileInformations", ThisKey="ID", OtherKey="ParentID")]
	public EntitySet<tblFileInformation> tblFileInformations
	{
		get
		{
			return this._tblFileInformations;
		}
		set
		{
			this._tblFileInformations.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblFileExtension_tblFileInformation", Storage="_tblFileExtension", ThisKey="FileExtensionID", OtherKey="ID", IsForeignKey=true)]
	public tblFileExtension tblFileExtension
	{
		get
		{
			return this._tblFileExtension.Entity;
		}
		set
		{
			tblFileExtension previousValue = this._tblFileExtension.Entity;
			if (((previousValue != value) 
						|| (this._tblFileExtension.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._tblFileExtension.Entity = null;
					previousValue.tblFileInformations.Remove(this);
				}
				this._tblFileExtension.Entity = value;
				if ((value != null))
				{
					value.tblFileInformations.Add(this);
					this._FileExtensionID = value.ID;
				}
				else
				{
					this._FileExtensionID = default(int);
				}
				this.SendPropertyChanged("tblFileExtension");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblFileInformation_tblFileInformation", Storage="_tblFileInformation1", ThisKey="ParentID", OtherKey="ID", IsForeignKey=true)]
	public tblFileInformation tblFileInformation1
	{
		get
		{
			return this._tblFileInformation1.Entity;
		}
		set
		{
			tblFileInformation previousValue = this._tblFileInformation1.Entity;
			if (((previousValue != value) 
						|| (this._tblFileInformation1.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._tblFileInformation1.Entity = null;
					previousValue.tblFileInformations.Remove(this);
				}
				this._tblFileInformation1.Entity = value;
				if ((value != null))
				{
					value.tblFileInformations.Add(this);
					this._ParentID = value.ID;
				}
				else
				{
					this._ParentID = default(Nullable<int>);
				}
				this.SendPropertyChanged("tblFileInformation1");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tlkpAccessType_tblFileInformation", Storage="_tlkpAccessType", ThisKey="AccessTypeID", OtherKey="ID", IsForeignKey=true)]
	public tlkpAccessType tlkpAccessType
	{
		get
		{
			return this._tlkpAccessType.Entity;
		}
		set
		{
			tlkpAccessType previousValue = this._tlkpAccessType.Entity;
			if (((previousValue != value) 
						|| (this._tlkpAccessType.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._tlkpAccessType.Entity = null;
					previousValue.tblFileInformations.Remove(this);
				}
				this._tlkpAccessType.Entity = value;
				if ((value != null))
				{
					value.tblFileInformations.Add(this);
					this._AccessTypeID = value.ID;
				}
				else
				{
					this._AccessTypeID = default(int);
				}
				this.SendPropertyChanged("tlkpAccessType");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tblFileInformation1 = this;
	}
	
	private void detach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tblFileInformation1 = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="[FILE].tlkpAccessType")]
public partial class tlkpAccessType : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _Name;
	
	private EntitySet<tblFileInformation> _tblFileInformations;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
	
	public tlkpAccessType()
	{
		this._tblFileInformations = new EntitySet<tblFileInformation>(new Action<tblFileInformation>(this.attach_tblFileInformations), new Action<tblFileInformation>(this.detach_tblFileInformations));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(7) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tlkpAccessType_tblFileInformation", Storage="_tblFileInformations", ThisKey="ID", OtherKey="AccessTypeID")]
	public EntitySet<tblFileInformation> tblFileInformations
	{
		get
		{
			return this._tblFileInformations;
		}
		set
		{
			this._tblFileInformations.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tlkpAccessType = this;
	}
	
	private void detach_tblFileInformations(tblFileInformation entity)
	{
		this.SendPropertyChanging();
		entity.tlkpAccessType = null;
	}
}
#pragma warning restore 1591
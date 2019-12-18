/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2019/12/4 13:50:19                           */
/*==============================================================*/
create database WBS_Goods
go
use WBS_Goods


if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_Collection')
            and   type = 'U')
   drop table Tb_Collection
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_CommodityEvaluation')
            and   type = 'U')
   drop table Tb_CommodityEvaluation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_CommoditySpecifica')
            and   type = 'U')
   drop table Tb_CommoditySpecifica
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_CommodityType')
            and   type = 'U')
   drop table Tb_CommodityType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_GoodsInfo')
            and   type = 'U')
   drop table Tb_GoodsInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_Img')
            and   type = 'U')
   drop table Tb_Img
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_MemberGrade')
            and   type = 'U')
   drop table Tb_MemberGrade
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_OrderInfo')
            and   type = 'U')
   drop table Tb_OrderInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_RoleInfo')
            and   type = 'U')
   drop table Tb_RoleInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_SaleNum')
            and   type = 'U')
   drop table Tb_SaleNum
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_ShoppingCart')
            and   type = 'U')
   drop table Tb_ShoppingCart
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_SystemInfo')
            and   type = 'U')
   drop table Tb_SystemInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_SystemRole')
            and   type = 'U')
   drop table Tb_SystemRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_UserInfo')
            and   type = 'U')
   drop table Tb_UserInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_areaInfo')
            and   type = 'U')
   drop table Tb_areaInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tb_consignee')
            and   type = 'U')
   drop table Tb_consignee
go

/*==============================================================*/
/* Table: Tb_Collection     收藏表                                    */
/*==============================================================*/
create table Tb_Collection (
   CollectionID         int                  not null identity,
   GoodsID              int                  null,
   MemberID             int                  null,
   constraint PK_TB_COLLECTION primary key (CollectionID)
)
go

/*==============================================================*/
/* Table: Tb_CommodityEvaluation   评价表                             */
/*==============================================================*/
create table Tb_CommodityEvaluation (
   CommodityID          int                  not null identity,
   GoodsID              int                  null,
   CommodEvaluaContent  varchar(200)         null,
   OrderInfoID          int                  null,
   CommodEvaluaTime     datetime             null default getdate(),
   CommodevaluaOrder    int                  null default 0, --0显示  1不显示
   constraint PK_TB_COMMODITYEVALUATION primary key (CommodityID)
)
go

/*==============================================================*/
/* Table: Tb_CommoditySpecifica      商品规格参考表                           */
/*==============================================================*/
create table Tb_CommoditySpecifica (
   CommodSpeciID        int                  not null identity,
   CommodSpeciName      varchar(50)          null,
   CommodSpeciOrder     int                  null,
   CommodSpeciDisplay   int                  null default 0,--0显示  1不显示
   CommodTypeID         int                  null,
   constraint PK_TB_COMMODITYSPECIFICA primary key (CommodSpeciID)
)
go

/*==============================================================*/
/* Table: Tb_CommodityType      商品分类表                                */
/*==============================================================*/
create table Tb_CommodityType (
   CommodTypeID         int                  not null identity,
   CommodTypeFatherID   int                  null,
   CommodTypeName       varchar(50)          null,
   CommodTypeOrder      int                  null,
   CommodTypeDisplay    int                  null default 0, --0显示  1不显示
   constraint PK_TB_COMMODITYTYPE primary key (CommodTypeID)
)
go

/*==============================================================*/
/* Table: Tb_GoodsInfo   商品表                                       */
/*==============================================================*/
create table Tb_GoodsInfo (
   GoodsID              int                  not null identity,
   GoodsName            varchar(50)          null,
   GoodsTitle           varchar(200)         null,
   GoodsDisplay         int                  null,
   GoodsPrice           decimal(18,2)        null,
   GoodsWeight          int                  null,
   GoodsRemark          varchar(2000)        null,
   GoodsState           int                  null default 0,--0上架  1未上架
   GoodsBorwseNum       int                  null,
   GoodsSaleNum         int                  null,
   GoodsEvaluaNum       int                  null,
   CommodTypeID         int                  null,
   GoodsFreight         int                  null default 0,--0包邮  1不包邮
   constraint PK_TB_GOODSINFO primary key (GoodsID)
)
go

/*==============================================================*/
/* Table: Tb_Img    系统图片表                                            */
/*==============================================================*/
create table Tb_Img (
   ImgID                int                  not null identity,
   ImgUrl               varchar(200)         null,
   ImgMasterMap         int                  null default 0,--0不是主图  1是主图
   ImgType              int                  null,
   PrimaryID            int                  null,
   constraint PK_TB_IMG primary key (ImgID)
)
go

/*==============================================================*/
/* Table: Tb_MemberGrade   用户表                                     */
/*==============================================================*/
create table Tb_MemberGrade (
   MemberID             int                  not null identity,
   MemberAccount        varchar(50)          null,
   MemberCode           varchar(200)         null,
   MemberNickName       varchar(50)          null,
   MemberName           varchar(50)          null,
   MemberGender         varchar(20)          null,
   MemberPhone          varchar(13)          null,
   MemberState          int                  null default 0,--0启用 1禁用
   MemberBalance        int                  null,
   constraint PK_TB_MEMBERGRADE primary key (MemberID)
)
go

/*==============================================================*/
/* Table: Tb_OrderInfo    订单表                                      */
/*==============================================================*/
create table Tb_OrderInfo (
   OrderInfoID          int                  not null identity,
   OrderInfoTime        datetime             null default getdate(),
   MemberID             int                  null,
   OrderInfoState       int                  null default 0,--0已付款   1已发货  2配送中 
   ConsigneeID          int                  null,
   constraint PK_TB_ORDERINFO primary key (OrderInfoID)
)
go

/*==============================================================*/
/* Table: Tb_RoleInfo    角色表                                       */
/*==============================================================*/
create table Tb_RoleInfo (
   RoleInfoID           int                  not null identity,
   RoleInfoName         varchar(50)          null,
   RoleInfoDesc         varchar(50)          null,
   constraint PK_TB_ROLEINFO primary key (RoleInfoID)
)
go

/*==============================================================*/
/* Table: Tb_SaleNum   订单明细表                                        */
/*==============================================================*/
create table Tb_SaleNum (
   SaleNumID            int                  not null identity,
   OrderInfoID          int                  null,
   GoodsID              int                  null,
   SaleNumState         int                  null,
   constraint PK_TB_SALENUM primary key (SaleNumID)
)
go

/*==============================================================*/
/* Table: Tb_ShoppingCart   购物车                                    */
/*==============================================================*/
create table Tb_ShoppingCart (
   ShoppingCartID       int                  not null identity,
   GoodsID              int                  null,
   ShoppingCartNum      int                  null,
   MemberID             int                  null,
   EvaluaTime           datetime             null default getdate(),
   constraint PK_TB_SHOPPINGCART primary key (ShoppingCartID)
)
go

/*==============================================================*/
/* Table: Tb_SystemInfo       菜单表                                  */
/*==============================================================*/
create table Tb_SystemInfo (
   SystemInfoID         int                  not null identity,
   SystemInfoName       varchar(50)          null,
   SystemInfoUrl        varchar(50)          null,
   SystemInfoOrder      int                  null,
   SystemInfoParentID   int                  null,
   constraint PK_TB_SYSTEMINFO primary key (SystemInfoID)
)
go

/*==============================================================*/
/* Table: Tb_SystemRole      角色菜单关联表                                   */
/*==============================================================*/
create table Tb_SystemRole (
   SystemInfoID         int                  null,
   RoleInfoID           int                  null
)
go

/*==============================================================*/
/* Table: Tb_UserInfo   管理员表                                        */
/*==============================================================*/
create table Tb_UserInfo (
   UserInfoID           int                  not null identity,
   UserInfoName         varchar(50)          null,
   UserInfoPwd          varchar(50)          null,
   UserInfoChinaName    varchar(50)          null,
   UserInfoSex          varchar(20)          null,
   UserInfoPhone        varchar(13)          null,
   UserInfoEmail        varchar(50)          null,
   UserInfoRemarks      varchar(200)         null,
   RoleInfoID           int                  null,
   constraint PK_TB_USERINFO primary key (UserInfoID)
)
go

/*==============================================================*/
/* Table: Tb_areaInfo    地区信息表                                       */
/*==============================================================*/
create table Tb_areaInfo (
   AreaInfoID           int                  not null identity,
   AreaInfoName         varchar(50)          null,
   AreaInfoOrder        int                  null,
   AreaInfoFatherID     int                  null,
   AreaInfoDefault      int                  null default 0,--0不默认 1默认
   AreaInfoState        int                  null,
   constraint PK_TB_AREAINFO primary key (AreaInfoID)
)
go

/*==============================================================*/
/* Table: Tb_consignee   收货人表                                       */
/*==============================================================*/
create table Tb_consignee (
   ConsigneeID          int                  not null identity,
   ConsigneeName        varchar(50)          null,
   ConsigneeAdder       varchar(200)         null,
   ConsigneeTel         varchar(13)          null,
   ConsigneeRemark      varchar(100)         null,
   constraint PK_TB_CONSIGNEE primary key (ConsigneeID)
)
go


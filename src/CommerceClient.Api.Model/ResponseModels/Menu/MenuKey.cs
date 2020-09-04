using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using JetBrains.Annotations;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
   public struct MenuKey
    {
        /// <summary>
        /// A <see cref="MenuKey"/>, that does not exist in any model. It has the same meaning as null (Nothing).
        /// </summary>
        public static readonly MenuKey NonExistent = new MenuKey(
            -1,
            MenuKind.NotDefined
        );

        /// <summary>
        /// Creates a new MenyKey by menuItemId and menuTypeID (int representation of MenuKind)
        /// </summary>
        public MenuKey(int menuItemID, int menuTypeID)
        {
            _MenuItemID = menuItemID;
            _MenuKind = (MenuKind) menuTypeID;
        }

        /// <summary>
        /// Creates a new MenyKey by menuItemId and menuTypeID (int representation of MenuKind)
        /// </summary>
        public MenuKey(long menuItemID, int menuTypeID)
        {
            if (menuItemID > int.MaxValue || menuItemID < int.MinValue)
            {
                throw new InvalidCastException(
                    string.Format(
                        "menuItemID value {0} is outside of integer range.",
                        menuItemID
                    )
                );
            }

            _MenuItemID = (int) menuItemID;
            _MenuKind = (MenuKind) menuTypeID;
        }

        /// <summary>
        /// Creates a new MenyKey by menuItemId and MenuKind
        /// </summary>
        public MenuKey(int menuItemID, MenuKind kind)
        {
            _MenuItemID = menuItemID;
            _MenuKind = kind;
        }

        /// <summary>
        /// Creates a new MenyKey by menuItemId and MenuKind
        /// </summary>
        public MenuKey(long menuItemID, MenuKind kind)
        {
            if (menuItemID > int.MaxValue || menuItemID < int.MinValue)
            {
                throw new InvalidCastException(
                    string.Format(
                        "menuItemID value {0} is outside of integer range.",
                        menuItemID
                    )
                );
            }

            _MenuItemID = (int) menuItemID;
            _MenuKind = kind;
        }

        // ReSharper disable once UnusedParameter.Local
        private MenuKey([NotNull] SerializationInfo info, StreamingContext text)
            : this()
        {
            _MenuItemID = info.GetInt32("i");
            _MenuKind = (MenuKind) info.GetInt32("k");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(
                "i",
                _MenuItemID
            );
            info.AddValue(
                "k",
                _MenuKind
            );
        }


        private static int BuildHashCode(int menuItemID, MenuKind kind)
        {
            unchecked // Overflow is fine, just wrap
            {
                var hash = 17;
                hash = hash * 23 + menuItemID.GetHashCode();
                hash = hash * 23 + kind.GetHashCode();
                return hash;
            }
        }

        //[ProtoBuf.ProtoMember(1)]
        private readonly int _MenuItemID;

        //[ProtoBuf.ProtoMember(2)]
        private readonly MenuKind _MenuKind;

        public int MenuItemID => _MenuItemID;
        public MenuKind MenuKind => _MenuKind;

        public override int GetHashCode() => BuildHashCode(
            _MenuItemID,
            _MenuKind
        );

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        //public int RedisCacheTtlMinutes => DocumentCacheConfiguration.Current.CacheTTLMinutesMenu;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string BuildCacheKey() => string.Format(
            "Menu[{0}, {1}]",
            MenuKind,
            MenuItemID
        );

        public override bool Equals(object obj) => obj is MenuKey && this == (MenuKey) obj;

        public static bool operator ==(MenuKey x, MenuKey y)
            => x.MenuItemID == y.MenuItemID && x.MenuKind == y.MenuKind;

        public static bool operator !=(MenuKey x, MenuKey y) => !(x == y);

        public static bool operator <(MenuKey x, MenuKey y)
            => (x.MenuKind < y.MenuKind || (x.MenuKind == y.MenuKind && x.MenuItemID < y.MenuItemID));

        public static bool operator <=(MenuKey x, MenuKey y)
            => (x.MenuKind < y.MenuKind || (x.MenuKind == y.MenuKind && x.MenuItemID <= y.MenuItemID));

        public static bool operator >(MenuKey x, MenuKey y)
            => (x.MenuKind > y.MenuKind || (x.MenuKind == y.MenuKind && x.MenuItemID > y.MenuItemID));

        public static bool operator >=(MenuKey x, MenuKey y)
            => (x.MenuKind > y.MenuKind || (x.MenuKind == y.MenuKind && x.MenuItemID >= y.MenuItemID));


        public int CompareTo(MenuKey other) => this == other ? 0 : (this > other ? 1 : -1);

        public override string ToString() => string.Format(
            "[{0}, {1}]",
            MenuKind,
            MenuItemID
        );
    }
}

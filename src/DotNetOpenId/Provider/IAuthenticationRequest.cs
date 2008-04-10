﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetOpenId.Provider {
	/// <summary>
	/// Instances of this interface represent incoming authentication requests.
	/// This interface provides the details of the request and allows setting
	/// the response.
	/// </summary>
	public interface IAuthenticationRequest : IRequest {
		/// <summary>
		/// Whether the consumer demands an immediate response.
		/// If false, the consumer is willing to wait for the identity provider
		/// to authenticate the user.
		/// </summary>
		bool Immediate { get; }
		/// <summary>
		/// The URL the consumer site claims to use as its 'base' address.
		/// </summary>
		Realm Realm { get; }
		/// <summary>
		/// Whether the Provider should help the user select a Claimed Identifier
		/// to send back to the relying party.
		/// </summary>
		bool IsDirectedIdentity { get; }
		/// <summary>
		/// The Local Identifier to this OpenID Provider of the user attempting 
		/// to authenticate.  Check <see cref="IsDirectedIdentity"/> to see if
		/// this value is valid.
		/// </summary>
		/// <remarks>
		/// This may or may not be the same as the Claimed Identifier that the user agent
		/// originally supplied to the relying party.  The Claimed Identifier
		/// endpoint may be delegating authentication to this provider using
		/// this provider's local id, which is what this property contains.
		/// Use this identifier when looking up this user in the provider's user account
		/// list.
		/// </remarks>
		Identifier LocalIdentifier { get; set; }
		/// <summary>
		/// The identifier that the user agent is claiming at the relying party site.
		/// Check <see cref="IsDirectedIdentity"/> to see if this value is valid.
		/// </summary>
		/// <remarks>
		/// This will not be the same as this provider's local identifier for the user
		/// if the user has set up his/her own identity page that points to this 
		/// provider for authentication.
		/// The provider may use this identifier for displaying to the user when
		/// asking for the user's permission to authenticate to the relying party.
		/// </remarks>
		Identifier ClaimedIdentifier { get; set; }
		/// <summary>
		/// Gets/sets whether the provider has determined that the 
		/// <see cref="ClaimedIdentifier"/> belongs to the currently logged in user
		/// and wishes to share this information with the consumer.
		/// </summary>
		bool? IsAuthenticated { get; set; }
	}
}

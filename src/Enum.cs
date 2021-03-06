namespace Tutkoo.mintyfusion.Moov.Sdk
{
    #region namespace
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class Enum { }
    #endregion Class

    #region Enum
    public enum GrantType
    {
        [StrProp("client_credentials")]
        ClientCredentials,

        [StrProp("refresh_token")]
        RefreshToken
    }

    public enum AccountScope
    {
        [StrProp("/accounts/{0}/profile.read")]
        Read,

        [StrProp("accounts.write")]
        Write,

        [StrProp("/accounts/{0}/profile.write")]
        Update,
    }

    public enum BankAccountScope
    {
        [StrProp("/accounts/{0}/bank-accounts.read")]
        Read,

        [StrProp("/accounts/{0}/bank-accounts.write")]
        Write
    }

    public enum CapabilitiesScope
    {
        [StrProp("/accounts/{0}/capabilities.read")]
        Read,

        [StrProp("/accounts/{0}/capabilities.write")]
        Write
    }

    public enum DocumentScope
    {
        [StrProp("/accounts/{0}/documents.read")]
        Read,

        [StrProp("/accounts/{0}/documents.write")]
        Write
    }

    public enum PaymentMethodScope
    {
        [StrProp("/accounts/{0}/payment-methods.read")]
        Read
    }

    public enum ProfileEncrichmentScope
    {
        [StrProp("/accounts/{0}/profile-enrichment.read")]
        Read,
    }

    public enum ProfileScope
    {
        [StrProp("/accounts/{0}/profile.read")]
        Read,

        [StrProp("/accounts/{0}/profile.write")]
        Write
    }

    public enum RepresentativeScope
    {
        [StrProp("/accounts/{0}/representatives.read")]
        Read,

        [StrProp("/accounts/{0}/representatives.write")]
        Write
    }

    public enum TransferScope
    {
        [StrProp("/accounts/{0}/transfers.read")]
        Read,

        [StrProp("/accounts/{0}/transfers.write")]
        Write
    }

    public enum WalletScope
    {
        [StrProp("/accounts/{0}/wallets.read")]
        Read
    }

    public enum InstitutionScope
    {
        [StrProp("/fed.read")]
        Read
    }

    public enum PingScope
    {
        [StrProp("ping.read")]
        Read
    }

    public enum TokenEndpoint
    {
        [StrProp("/oauth2/token")]
        Get,

        [StrProp("/oauth2/revoke")]
        Revoke
    }

    public enum AccountEndpoint
    {
        [StrProp("/accounts")]
        List,

        [StrProp("/accounts")]
        Create,

        [StrProp("/accounts/{0}")]
        Get,

        [StrProp("/accounts/{0}")]
        Update,

        [StrProp("/accounts/{0}")]
        Patch
    }

    public enum TermsOfServiceEndpoint
    {
        [StrProp("/tos-token")]
        GetToken
    }

    public enum CapabilityEndpoint
    {
        [StrProp("/accounts/{0}/capabilities/{1}")]
        GetRequested,

        [StrProp("/{0}/capabilities/{1}")]
        Disable,

        [StrProp("/accounts/{0}/capabilities")]
        List,

        [StrProp("/accounts/{0}/capabilities")]
        Request
    }

    public enum BankAccountEndpoint
    {
        [StrProp("/accounts/{0}/bank-accounts")]
        Create,

        [StrProp("/accounts/{0}/bank-accounts")]
        List,

        [StrProp("/accounts/{0}/bank-accounts/{1}")]
        Get,

        [StrProp("/accounts/{0}/bank-accounts/{1}")]
        Disable,

        [StrProp("/accounts/{0}/bank-accounts/{1}/micro-deposits")]
        InitiateMicroDepositeVerification,

        [StrProp("/accounts/{0}/bank-accounts/{1}/micro-deposits")]
        CompleteMicroDepositeVerification
    }

    public enum PaymentMethodEndpoint
    {
        [StrProp("/accounts/{0}/payment-methods")]
        List,

        [StrProp("/accounts/{0}/payment-methods/{1}")]
        Get
    }

    public enum TransferEndpoint
    {
        [StrProp("/transfers")]
        Create,

        [StrProp("/transfers")]
        List,

        [StrProp("/transfers/{0}")]
        Get,

        [StrProp("/transfer-options")]
        GetTransferOptions
    }

    public enum RepresentativeEndpoint
    {
        [StrProp("/accounts/{0}/representatives")]
        Create,

        [StrProp("/accounts/{0}/representatives")]
        List,

        [StrProp("/accounts/{0}/representatives/{1}")]
        Get,

        [StrProp("/accounts/{0}/representatives/{1}")]
        Disable,

        [StrProp("/accounts/{0}/representatives/{1}")]
        Update
    }

    public enum WalletEndpoint
    {
        [StrProp("/accounts/{0}/wallets")]
        List,

        [StrProp("/accounts/{0}/wallets/{1}")]
        Get
    }

    public enum InstitutionEndpoint
    {
        [StrProp("/institutions/{rail}/search")]
        Search
    }

   public enum Rail
   {
       [StrProp("ach")]
       Ach,

       [StrProp("wire")]
       Wire
    }
    
    public enum Capability
    {
        [StrProp("transfers")]
        Transfers,

        [StrProp("send-funds")]
        SendFunds,

        [StrProp("collect-funds")]
        CollectFunds,

        [StrProp("wallet")]
        Wallet,

        [StrProp("receive-1099-nec")]
        Receive1099nec,

        [StrProp("receive-1099-k")]
        Receive1099K
    }
    #endregion Enum
}
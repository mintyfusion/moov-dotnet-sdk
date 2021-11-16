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

    public enum Scope
    {
        [StrProp("accounts.write")]
        AccountsWrite,

        [StrProp("/accounts/{0}/bank-accounts.read")]
        BankAccountsRead,

        [StrProp("/accounts/{0}/bank-accounts.write")]
        BankAccountsWrite,

        [StrProp("/accounts/{0}/capabilities.read")]
        CapabilitiesRead,

        [StrProp("/accounts/{0}/capabilities.write")]
        CapabilitiesWrite,

        [StrProp("/accounts/{0}/documents.read")]
        DocumentsRead,

        [StrProp("/accounts/{0}/documents.write")]
        DocumentsWrite,

        [StrProp("/accounts/{0}/payment-methods.read")]
        PaymentMethods,

        [StrProp("/accounts/{0}/profile-enrichment.read")]
        ProfileImage,

        [StrProp("/accounts/{0}/profile.read")]
        ProfileRead,

        [StrProp("/accounts/{0}/profile.write")]
        ProfileWrite,

        [StrProp("/accounts/{0}/representatives.read")]
        RepresentativesRead,

        [StrProp("/accounts/{0}/representatives.write")]
        RepresentativesWrite,

        [StrProp("/accounts/{0}/transfers.write")]
        TransfersWrite,

        [StrProp("/accounts/{0}/transfers.read")]
        TransfersRead,

        [StrProp("/accounts/{0}/wallets.read")]
        WalletsRead,

        [StrProp("fed.read")]
        FedRead,

        [StrProp("ping.read")]
        Ping
    }

    public enum Endpoint
    {
        [StrProp("/oauth2/token")]
        GetAccessToken,

        [StrProp("/oauth2/revoke")]
        RevokeToken,

        [StrProp("/accounts")]
        GetAccounts,

        [StrProp("/accounts")]
        CreateAccount,

        [StrProp("/accounts/{0}")]
        GetAccountById,

        [StrProp("/accounts/{0}")]
        UpdateAccount,

        [StrProp("/accounts/{0}")]
        PatchAccount,

        [StrProp("/tos-token")]
        GetTermsOfServiceToken,

        [StrProp("/accounts/{0}/capabilities/{1}")]
        GetRequestedCapabilityForAccountById,

        [StrProp("/{0}/capabilities/{1}")]
        DisableCapability,

        [StrProp("/accounts/{0}/capabilities")]
        GetCapability,

        [StrProp("/accounts/{0}/capabilities")]
        RequestCapability,

        [StrProp("/accounts/{0}/bank-accounts")]
        AddBankAccount,

        [StrProp("/accounts/{0}/bank-accounts")]
        ListBankAccounts,

        [StrProp("/accounts/{0}/bank-accounts/{1}")]
        GetBankAccount,

        [StrProp("/accounts/{0}/bank-accounts/{1}")]
        DisableBankAccount,

        [StrProp("/accounts/{0}/bank-accounts/{1}/micro-deposits")]
        InitiateMicroDeposite,

        [StrProp("/accounts/{0}/bank-accounts/{1}/micro-deposits")]
        CompleteMicroDeposite,

        [StrProp("/accounts/{0}/payment-methods")]
        PaymentMethods,

        [StrProp("/accounts/{0}/payment-methods/{1}")]
        GetPaymentMethod,

        [StrProp("/transfers")]
        CreateTransfer,

        [StrProp("/transfers")]
        ListTransfers,

        [StrProp("/transfers/{0}")]
        GetTransfer,

        [StrProp("/transfer-options")]
        GetTransferOptions,

        [StrProp("/accounts/{accountID}/representatives")]
        CreateRepresentative,

        [StrProp("/accounts/{accountID}/representatives")]
        ListRepresentative,

        [StrProp("/accounts/{accountID}/representatives/{representativeID}")]
        GetRepresentative,

        [StrProp("/accounts/{accountID}/representatives/{representativeID}")]
        DisableRepresentative,

        [StrProp("/accounts/{accountID}/representatives")]
        UpdateRepresentative,

        [StrProp("/accounts/{accountID}/wallets")]
        ListWallets,

        [StrProp("/accounts/{accountID}/wallets/{walletID}")]
        GetWalletById,

        [StrProp("/institutions/{rail}/search")]
        SearchInstitution
    }
    #endregion Enum
}
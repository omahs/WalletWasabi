using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WalletWasabi.BuyAnything;

namespace WalletWasabi.Fluent.ViewModels.Wallets.Buy.Workflows.ShopinBit;

public sealed class ShopinBitDataProvider : IShopinBitDataProvider
{
	private readonly BuyAnythingManager _buyAnythingManager;
	private Country? _currentCountry;

	public ShopinBitDataProvider(BuyAnythingManager buyAnythingManager)
	{
		_buyAnythingManager = buyAnythingManager;
	}

	public Country[] GetCountries()
	{
		return _buyAnythingManager.Countries.ToArray();
	}

	public async Task<WebClients.ShopWare.Models.State[]> GetStatesForCountryAsync(string countryName, CancellationToken cancellationToken)
	{
		return await _buyAnythingManager.GetStatesForCountryAsync(countryName, cancellationToken);
	}

	public Country? GetCurrentCountry()
	{
		return _currentCountry;
	}

	public void SetCurrentCountry(Country? country)
	{
		_currentCountry = country;
	}
}
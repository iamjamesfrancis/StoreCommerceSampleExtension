import { ProxyEntities } from "PosApi/Entities";
import { ArrayExtensions, ObjectExtensions } from "PosApi/TypeExtensions";
import { IExtensionCommandContext } from "PosApi/Extend/Views/AppBarCommands";
import * as SearchView from "PosApi/Extend/Views/SearchView";
import MessageDialog from "../DialogSample/MessageDialog";
export default class ViewCustomerSummaryCommand extends SearchView.CustomerSearchExtensionCommandBase {
    private _customerSearchResults: ProxyEntities.GlobalCustomer[];

    /**
    * Creates a new instance of the ViewCustomerSummaryCommand class.
    * @param {IExtensionCommandContext<CustomerDetailsView.ICustomerSearchToExtensionCommandMessageTypeMap>} context The command context.
    * @remarks The command context contains APIs through which a command can communicate with POS.
    */
    constructor(context: IExtensionCommandContext<SearchView.ICustomerSearchToExtensionCommandMessageTypeMap>) {
        super(context);
        this.id = "viewCustomerSummaryCommand";
        this.label = context.resources.getString("string_1");
        this.extraClass = "iconLightningBolt";
        this._customerSearchResults = [];

        this.searchResultsSelectedHandler = (data: SearchView.CustomerSearchSearchResultSelectedData): void => {
            this._customerSearchResults = data.customers;
            this.canExecute = true;
        };

        this.searchResultSelectionClearedHandler = (): void => {
            this._customerSearchResults = [];
            this.canExecute = false;
        };
    }

    /**
    * Initializes the command.
    * @param {CustomerDetailsView.ICustomerDetailsExtensionCommandState} state The state used to initialize the command.
    */
    protected init(state: SearchView.ICustomerSearchExtensionCommandState): void {
        this.isVisible = true;
    }

    /**
    * Executes the command.
    */
    protected execute(): void {
        let customer: ProxyEntities.GlobalCustomer = ArrayExtensions.firstOrUndefined(this._customerSearchResults);
        if (!ObjectExtensions.isNullOrUndefined(customer)) {
            let message: string = "Customer Account: " + (customer.AccountNumber || "") + " | ";
            message += "Name: " + customer.FullName + " | ";
            message += "Phone Number: " + customer.Phone + " | ";
            message += "Email Address: " + customer.Email;
            MessageDialog.show(this.context, message);
        }
    }
}
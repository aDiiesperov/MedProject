import store from "../../store";
import { actions as $A } from "../../store/types";

export function actionResolver(item) {
  switch (item.Status?.toLowerCase()) {
    case "requested":
      return [
        {
          name: "Cancel",
          cssClass: "btn btn-danger btn-sm",
          onClick: () => {},
        },
      ];
    // case "accepted":
    // case "canceled":
    // case "avaliable":
    default:
      return [
        {
          name: "Request",
          cssClass: "btn btn-primary btn-sm",
          async onClick() {
            const quantity = +prompt(
              "How much medication do you want to order?",
              0
            );

            if (quantity > 0) {
              const data = {
                Quantity: quantity,
                MedicationId: item.MedicationId,
                PharmacyId: item.PharmacyId,
              };
              await store.dispatch($A.MED_ACTION_REQUEST, data);
            }
          },
        },
      ];
  }
}

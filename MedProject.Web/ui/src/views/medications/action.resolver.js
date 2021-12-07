import store from "../../store";
import { actions as $A } from "../../store/types";

async function requestMeds(item) {
  const quantity = +prompt("How much medication do you want to order?", 0);

  if (quantity > 0) {
    const data = {
      Quantity: quantity,
      MedicationId: item.MedicationId,
      PharmacyId: item.PharmacyId,
    };
    await store.dispatch($A.MED_ACTION_REQUEST, data);
  }
}

export function actionResolver(item) {
  switch (item.Status?.toLowerCase()) {
    case "requested":
      return [
        {
          name: "Change",
          cssClass: "btn btn-primary btn-sm",
          onClick: requestMeds.bind(null, item),
        },
        {
          name: "Cancel",
          cssClass: "btn btn-danger btn-sm",
          onClick: async () => {
            const data = {
              MedicationId: item.MedicationId,
              PharmacyId: item.PharmacyId,
            };
            await store.dispatch($A.MED_ACTION_CANCEL, data);
          },
        },
      ];
    default:
      return [
        {
          name: "Request",
          cssClass: "btn btn-success btn-sm",
          onClick: requestMeds.bind(null, item),
        },
      ];
  }
}

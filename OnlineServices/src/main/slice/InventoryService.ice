#ifndef INVENTORY_SERVICE_H
#define INVENTORY_SERVICE_H

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

				interface InventoryService
				{
				    RmiInventory getInventory();
				    void updateItem(RmiItem rmiItem);

				};

            };
        };
    };
};

#endif
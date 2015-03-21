
    <add name="SupermarketsSqlEntities" connectionString="metadata=res://*/SupermarketsSQLEntities.csdl|res://*/SupermarketsSQLEntities.ssdl|res://*/SupermarketsSQLEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=Supermarkets;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

	
	  <MySQL>
    <Replication>
      <ServerGroups>
        <Group name="Fabric" groupType="MySql.Fabric.FabricServerGroup, MySql.Fabric.Plugin">
          <Servers>
            <Server name="fabric" connectionstring="server=localhost;port=;uid=;password=;" />
          </Servers>
        </Group>
      </ServerGroups>
    </Replication>
  </MySQL>
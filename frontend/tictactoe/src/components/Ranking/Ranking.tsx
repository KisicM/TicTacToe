import UserView from '../../models/userView';
import styles from './Ranking.module.css';

const Ranking = (): JSX.Element => {
    const users: Array <UserView> = [
        { place: 1, username: "Mihajlo", points: 100, played: 100 },
        { place: 2, username: "Lazar", points: 95, played: 100 },
        { place: 3, username: "Nemanja", points: 40, played: 100 },
      ]
    return (
        <table className={styles.myTable}>
            <thead>
                <tr>
                    <th className={styles.myTh}>Place</th>
                    <th className={styles.myTh}>Username</th>
                    <th className={styles.myTh}>Points</th>
                    <th className={styles.myTh}>Total matches</th>
                </tr>
            </thead>
            <tbody>
                {users.map((user) => {
                    return (
                    <tr key={user.username}>
                        <td className={styles.myTd}>{user.place}</td>
                        <td className={styles.myTd}>{user.username}</td>
                        <td className={styles.myTd}>{user.points}</td>
                        <td className={styles.myTd}>{user.played}</td>
                    </tr>
                    )
                })}
            </tbody>
        </table>
    );
}

export default Ranking